using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace OrderResults.Models.FormRecognizer
{

    public class Line
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("boundingBox")]
        public List<double> BoundingBox { get; set; }

        [JsonPropertyName("spans")]
        public List<Span> Spans { get; set; }
    }

}