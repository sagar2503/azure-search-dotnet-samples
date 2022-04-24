using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace OrderResults.Models.FormRecognizer
{ 

    public class BoundingRegion
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("boundingBox")]
        public List<double> BoundingBox { get; set; }
    }

}