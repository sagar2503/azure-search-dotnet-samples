using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace OrderResults.Models.FormRecognizer
{

    public class Word
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("boundingBox")]
        public List<double> BoundingBox { get; set; }

        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        [JsonPropertyName("span")]
        public Span Span { get; set; }
    }

}