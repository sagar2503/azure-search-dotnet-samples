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

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("metadataList")]
        public List<string> MetadataList { get; set; }

        [JsonPropertyName("pageNumber")]
        public List<string> PageNumber { get; set; }

        [JsonPropertyName("pageImageUrl")]
        public List<string> PageImageUrl { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("entities")]
        public List<string> Entities { get; set; }

        [JsonPropertyName("hocrPages")]
        public List<string> HocrPages { get; set; }

        [JsonPropertyName("cryptonyms")]
        public List<string> Cryptonyms { get; set; }

        [JsonPropertyName("demoBoost")]
        public object DemoBoost { get; set; }

        [JsonPropertyName("demoInitialPage")]
        public object DemoInitialPage { get; set; }
    }


}
