using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderResults.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents;
using Azure;
using Azure.Search.Documents.Models;
using OrderResults.Models.MemberHandBook;

namespace OrderResults.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            InitSearch();
            string facetName = _configuration["FacetName"];

            // Set up the facets call in the search parameters.
            SearchOptions options = new SearchOptions();
            // Search for up to 20 amenities.
            //options.Facets.Add("Tags,count:20");
            options.Facets.Add(facetName+ ",count:20");

            SearchResults<MemberHandbook> searchResult = await _searchClient.SearchAsync<MemberHandbook>("*", options);

            // Convert the results to a list that can be displayed in the client.
            List<string> facets = searchResult.Facets[facetName].Select(x => x.Value.ToString()).ToList();

            // Initiate a model with a list of facets for the first view.
            SearchData model = new SearchData(facets);

            // Save the facet text for the next view.
            SaveFacets(model, false);

            // Render the view including the facets.
            return View(model);
        }

        // Save the facet text to temporary storage, optionally saving the state of the check boxes.
        private void SaveFacets(SearchData model, bool saveChecks = false)
        {
            for (int i = 0; i < model.facetText.Length; i++)
            {
                TempData["facet" + i.ToString()] = model.facetText[i];
                if (saveChecks)
                {
                    TempData["faceton" + i.ToString()] = model.facetOn[i];
                }
            }
            TempData["facetcount"] = model.facetText.Length;
        }

        // Recover the facet text to a model, optionally recoving the state of the check boxes.
        private void RecoverFacets(SearchData model, bool recoverChecks = false)
        {
            // Create arrays of the appropriate length.
            model.facetText = new string[(int)TempData["facetcount"]];
            if (recoverChecks)
            {
                model.facetOn = new bool[(int)TempData["facetcount"]];
            }

            for (int i = 0; i < (int)TempData["facetcount"]; i++)
            {
                model.facetText[i] = TempData["facet" + i.ToString()].ToString();
                if (recoverChecks)
                {
                    model.facetOn[i] = (bool)TempData["faceton" + i.ToString()];
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchData model)
        {
            try
            {
                InitSearch();

                int page;

                if (model.paging != null && model.paging == "next")
                {
                    // Recover the facet text, and the facet check box settings.
                    RecoverFacets(model, true);

                    // Increment the page.
                    page = (int)TempData["page"] + 1;

                    // Recover the search text.
                    model.searchText = TempData["searchfor"].ToString();
                }
                else
                {
                    // First search with text. 
                    // Recover the facet text, but ignore the check box settings, and use the current model settings.
                    RecoverFacets(model, false);

                    // First call. Check for valid text input, and valid scoring profile.
                    if (model.searchText == null)
                    {
                        model.searchText = "";
                    }
                    if (model.scoring == null)
                    {
                        //model.scoring = "Default";
                        model.scoring = "Default";                        
                    }
                    page = 0;
                }

                List<string> lstHighlitedFeilds = new List<string>();
                lstHighlitedFeilds.Add("Text");
                // Setup the search parameters.
                var options = new SearchOptions
                {
                    Filter = "(entities/any(x: search.in(x,'ADA|Anthem', '|')))",
                    SearchMode = SearchMode.All,

                    // Skip past results that have already been returned.
                    Skip = page * GlobalVariables.ResultsPerPage,

                    // Take only the next page worth of results.
                    Size = GlobalVariables.ResultsPerPage,

                    // Include the total number of results.
                    IncludeTotalCount = true,
                   // HighlightFields = lstHighlitedFeilds,
                   //HighlightPreTag = "<mark>",
                   
                   //HighlightPostTag = "</mark>"
                };
                // Select the data properties to be returned.
                //options.Select.Add("HotelName");
                //options.Select.Add("Description");
                //options.Select.Add("Tags");
                //options.Select.Add("Rooms");
                //options.Select.Add("Rating");
                //options.Select.Add("LastRenovationDate");
                options.Select.Add("fileName");
                options.Select.Add("metadata");                
                options.Select.Add("text");
                options.Select.Add("entities");
                options.Select.Add("hocrPages");
                //options.Select.Add("metadataList");
                //options.Select.Add("pageNumber");
                //options.Select.Add("pageImageUrl");
                options.Select.Add("demoBoost");
                options.Select.Add("demoInitialPage");
                options.HighlightFields.Add("text");

                List<string> parameters = new List<string>();
                // Set the ordering based on the user's radio button selection.
                switch (model.scoring)
                {
                    case "RatingRenovation":
                        // Set the ordering/scoring parameters.
                        options.OrderBy.Add("Rating desc");
                        options.OrderBy.Add("LastRenovationDate desc");
                        break;

                    case "boostEntities":
                        {
                            options.ScoringProfile = model.scoring;

                            // Create a string list of amenities that have been clicked.
                            for (int a = 0; a < model.facetOn.Length; a++)
                            {
                                if (model.facetOn[a])
                                {
                                    parameters.Add(model.facetText[a]);
                                }
                            }

                            if (parameters.Count > 0)
                            {
                                options.ScoringParameters.Add($"entities-{ string.Join(',', parameters)}");
                            }
                            else
                            {
                                // No amenities selected, so set profile back to default.
                                options.ScoringProfile = "";
                            }
                        }
                        break;

                    case "renovatedAndHighlyRated":
                        options.ScoringProfile = model.scoring;
                        break;

                    default:
                        break;
                }

                // For efficiency, the search call should be asynchronous, so use SearchAsync rather than Search.
                //model.resultList = await _searchClient.SearchAsync<Hotel>(model.searchText, options);

                //Sagar
                model.resultList = await _searchClient.SearchAsync<MemberHandbook>(model.searchText, options);


                // Ensure TempData is stored for the next call.
                TempData["page"] = page;
                TempData["searchfor"] = model.searchText;
                TempData["scoring"] = model.scoring;
                SaveFacets(model, true);

                // Calculate the room rate ranges.

                //await foreach (var result in model.resultList.GetResultsAsync())
                //{
                //    var cheapest = 0d;
                //    var expensive = 0d;

                //    foreach (var room in result.Document.Rooms)
                //    {
                //        var rate = room.BaseRate;
                //        if (rate < cheapest || cheapest == 0)
                //        {
                //            cheapest = (double)rate;
                //        }
                //        if (rate > expensive)
                //        {
                //            expensive = (double)rate;
                //        }
                //    }

                //    result.Document.cheapest = cheapest;
                //    result.Document.expensive = expensive;
                //
                //}
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = "1" });
            }

            return View("Index", model);
        }

        public async Task<ActionResult> NextAsync(SearchData model)
        {
            // Set the next page setting, and call the Index(model) action.
            model.paging = "next";
            model.scoring = TempData["scoring"].ToString();

            await Index(model);

            // Create an empty list.
            var nextHotels = new List<string>();

            // Add a hotel details to the list.
            await foreach (var result in model.resultList.GetResultsAsync())
            {
                var PageNumber = $"{ Convert.ToInt32(result.Document.PageNumber)}";
                var highlitedText = $"{result.Document.SearchHighlights.Text}";
                //highlitedText.Replace("<em>", "<mark>");
                //highlitedText.Replace("</em>", "</mark>");
                //var lastRenovatedText = $"Last renovated: {result.Document.LastRenovationDate.Value.Year}";
                var pageImageUrl = $"{result.Document.PageImageUrl}";
                //string amenities = string.Join(", ", result.Document.Tags);
                //string fullDescription = result.Document.Description;
                //fullDescription += $"\nAmenities: {amenities}";
                
                // Add strings to the list.
                nextHotels.Add(result.Document.FileName);
                nextHotels.Add(PageNumber);
                nextHotels.Add(pageImageUrl);
                nextHotels.Add(highlitedText);
                  //nextHotels.Add(fullDescription);
            }

            // Rather than return a view, return the list of data.
            return new JsonResult(nextHotels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static SearchIndexClient _indexClient;
        private static SearchClient _searchClient;
        private static IConfigurationBuilder _builder;
        private static IConfigurationRoot _configuration;

        private void InitSearch()
        {
            // Create a configuration using the appsettings file.
            _builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _configuration = _builder.Build();

            // Pull the values from the appsettings.json file.
            string searchServiceUri = _configuration["SearchServiceUri"];
            string queryApiKey = _configuration["SearchServiceQueryApiKey"];
            string serachIndexName = _configuration["SearchServiceIndexName"];

            // Create a service and index client.
            _indexClient = new SearchIndexClient(new Uri(searchServiceUri), new AzureKeyCredential(queryApiKey));
            _searchClient = _indexClient.GetSearchClient(serachIndexName);
        }

        public async Task<ActionResult> FacetAsync(SearchData model)
        {
            try
            {
                // Filters set by the model override those stored in temporary data.
                string catFilter;
                string ameFilter;
                //if (model.categoryFilter != null)
                //{
                //    catFilter = model.categoryFilter;
                //}
                //else
                //{
                //    catFilter = TempData["categoryFilter"].ToString();
                //}

                if (model.entityFilter != null)
                {
                    ameFilter = model.entityFilter;
                }
                else
                {
                    ameFilter = TempData["entityFilter"].ToString();
                }

                // Recover the search text.
                model.searchText = TempData["searchfor"].ToString();

                // Initiate a new search.
                await RunQueryAsync(model, 0, 0,  ameFilter).ConfigureAwait(false);
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = "2" });
            }

            return View("Index", model);
        }

        private async Task<ActionResult> RunQueryAsync(SearchData model, int page, int leftMostPage,  string entityFilter)
        {
            InitSearch();

            string facetFilter = "";

            //if (catFilter.Length > 0 && ameFilter.Length > 0)
            if (entityFilter.Length > 0)
            {
                // Both facets apply.
                //facetFilter = $"{catFilter} and {ameFilter}";
                facetFilter = $"{entityFilter}";
            }
            else
            {
                // One, or zero, facets apply.
                //facetFilter = $"{catFilter}{ameFilter}";
                facetFilter = $"{entityFilter}";
            }

            var options = new SearchOptions
            {
                Filter = facetFilter,

                SearchMode = SearchMode.All,

                // Skip past results that have already been returned.
                Skip = page * GlobalVariables.ResultsPerPage,

                // Take only the next page worth of results.
                Size = GlobalVariables.ResultsPerPage,

                // Include the total number of results.
                IncludeTotalCount = true,
            };

            // Return information on the text, and number, of facets in the data.
            //options.Facets.Add("Category,count:20");
            options.Facets.Add("entities,count:20");

            // Enter Hotel property names into this list, so only these values will be returned.
            //options.Select.Add("HotelName");
            //options.Select.Add("Description");
            //options.Select.Add("Category");
            //options.Select.Add("Tags");
            options.Select.Add("fileName");
            //options.Select.Add("metadata");
            //options.Select.Add("text");
            options.Select.Add("entities");
            options.Select.Add("hocrPages");


            // For efficiency, the search call should be asynchronous, so use SearchAsync rather than Search.
            model.resultList = await _searchClient.SearchAsync<MemberHandbook>(model.searchText, options).ConfigureAwait(false);

            // This variable communicates the total number of pages to the view.
            model.pageCount = ((int)model.resultList.TotalCount + GlobalVariables.ResultsPerPage - 1) / GlobalVariables.ResultsPerPage;

            // This variable communicates the page number being displayed to the view.
            model.currentPage = page;

            // Calculate the range of page numbers to display.
            if (page == 0)
            {
                leftMostPage = 0;
            }
            else if (page <= leftMostPage)
            {
                // Trigger a switch to a lower page range.
                leftMostPage = Math.Max(page - GlobalVariables.PageRangeDelta, 0);
            }
            else if (page >= leftMostPage + GlobalVariables.MaxPageRange - 1)
            {
                // Trigger a switch to a higher page range.
                leftMostPage = Math.Min(page - GlobalVariables.PageRangeDelta, model.pageCount - GlobalVariables.MaxPageRange);
            }
            model.leftMostPage = leftMostPage;

            // Calculate the number of page numbers to display.
            model.pageRange = Math.Min(model.pageCount - leftMostPage, GlobalVariables.MaxPageRange);

            // Ensure Temp data is stored for the next call.
            TempData["page"] = page;
            TempData["leftMostPage"] = model.leftMostPage;
            TempData["searchfor"] = model.searchText;
            //TempData["categoryFilter"] = catFilter;
            TempData["entityFilter"] = entityFilter;

            // Return the new view.
            return View("Index", model);
        }

    }
}
