using Azure.Search.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderResults.Models.MemberHandBook
{
    public class MemberHandbook
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
        [JsonPropertyName("metadataList")]
        public List<string> MetadataList { get; set; }

        [SearchableField()]
        [JsonPropertyName("pageNumber")]
        public List<string> PageNumber { get; set; }

        [SearchableField()]
        [JsonPropertyName("pageImageUrl")]
        public List<string> PageImageUrl { get; set; }

        [SearchableField()]
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [SearchableField(IsFacetable =true)]
        [JsonPropertyName("entities")]
        public List<string> Entities { get; set; }

        [JsonPropertyName("hocrPages")]
        public List<string> HocrPages { get; set; }

        [SearchableField(IsFacetable = true)]
        [JsonPropertyName("cryptonyms")]
        public List<Cryptonyms> Cryptonyms { get; set; }


        [SearchableField(IsFilterable = true)]
        [JsonPropertyName("demoBoost")]
        public object DemoBoost { get; set; }

        [JsonPropertyName("demoInitialPage")]
        public object DemoInitialPage { get; set; }
    }


}
