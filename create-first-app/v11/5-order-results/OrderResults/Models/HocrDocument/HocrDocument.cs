using Azure.Search.Documents.Indexes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderResults.Models.HocrDocument
{
    public class HocrDocument
    {
        [JsonPropertyName("@search.score")]
        public double SearchScore { get; set; }

        [JsonPropertyName("@search.highlights")]
        public SearchHighlights SearchHighlights { get; set; }

        [SimpleField(IsFilterable = false, IsKey = true)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [SearchableField()]
        [JsonPropertyName("fileName")]
        public string FileName { get; set; }


        [SearchableField()]
        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [SearchableField()]
        [JsonIgnore]
        [JsonPropertyName("metadataList")]
        public List<string> MetadataList { get; set; }

        [SearchableField()]
        [JsonIgnore]
        [JsonPropertyName("pageNumber")]
        public List<string> PageNumber { get; set; }

        [SearchableField()]
        [JsonIgnore]
        [JsonPropertyName("pageImageUrl")]
        public List<string> PageImageUrl { get; set; }

        [SearchableField()]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [SearchableField(IsFacetable = true)]
        [JsonPropertyName("entities")]
        public List<string> Entities { get; set; }

        [JsonPropertyName("hocrPages")]
        public List<string> HocrPagesString { get; set; }

        public List<HocrPages> HocrPagesObject
        {
            get => DeserializeHocrPages();
            //private set => _volume = value;
        }

        private List<HocrPages> DeserializeHocrPages()
        {
            List<HocrPages> hp = new List<HocrPages>();
            foreach (string p in HocrPagesString)
            {
                HocrPages hpages = Newtonsoft.Json.JsonConvert.DeserializeObject<HocrPages>(p);
                hp.Add(hpages);
            }
            return hp;
        }

        [SearchableField(IsFacetable = true)]
        [JsonPropertyName("cryptonyms")]
        [JsonIgnore]
        public List<Cryptonyms> Cryptonyms { get; set; }


        [SearchableField(IsFilterable = true)]
        [JsonPropertyName("demoBoost")]
        public object DemoBoost { get; set; }

        [JsonPropertyName("demoInitialPage")]
        public object DemoInitialPage { get; set; }
    }


}
