using Azure.Search.Documents.Models;
using OrderResults.Models.MemberHandBook;
using System.Collections.Generic;

namespace OrderResults.Models
{
    public static class GlobalVariables
    {
        public static int ResultsPerPage
        {
            get
            {
                return 3;
            }
        }
        public static int MaxPageRange
        {
            get
            {
                return 5;
            }
        }

        public static int PageRangeDelta
        {
            get
            {
                return 2;
            }
        }
        public static string facetName ;
        public static string facetCountConfig ;
        public static string selectFields ;
        public static string searchFields ;
        public static string highlightFields ;
    }
    public class SearchData
    {
        public SearchData()
        {
        }

        // Constructor to initialize the list of facets sent from the controller.
        public SearchData(List<string> facets)
        {
            facetText = new string[facets.Count];

            for (int i = 0; i < facets.Count; i++)
            {
                facetText[i] = facets[i];
            }
        }

        // Array to hold the text for each amenity.
        public string[] facetText { get; set; }

        // Array to hold the setting for each amenitity.
        public bool[] facetOn { get; set; }

        // The text to search for.
        public string searchText { get; set; }

        // Record if the next page is requested.
        public string paging { get; set; }

        // The list of results.
        //public SearchResults<Hotel> resultList;
        //Sagar : Use typeof("classname") in T
        public SearchResults<HocrDocument> resultList;


        // The current page being displayed.
        public int currentPage { get; set; }

        // The total number of pages of results.
        public int pageCount { get; set; }

        // The left-most page number to display.
        public int leftMostPage { get; set; }

        // The number of page numbers to display - which can be less than MaxPageRange towards the end of the results.
        public int pageRange { get; set; }


        // Property, and text of a facet (such as "Budget"). Used to communicate this text to the controller.
        public string categoryFilter { get; set; }
        public string entityFilter { get; set; }
        public string scoring { get; set; }
        public List<string> paramFilter { get; set; }



    }
}
