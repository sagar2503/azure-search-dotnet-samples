using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace OrderResults.Models.FormRecognizer{ 

    public class Entity
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("subCategory")]
        public string SubCategory { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("boundingRegions")]
        public List<BoundingRegion> BoundingRegions { get; set; }

        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        [JsonPropertyName("spans")]
        public List<Span> Spans { get; set; }
    }

}