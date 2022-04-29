using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace OrderResults.Models.FormRecognizer
{

    public class SelectionMark
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("boundingBox")]
        public List<double> BoundingBox { get; set; }

        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        [JsonPropertyName("span")]
        public Span Span { get; set; }
    }

}