using System.Text.Json.Serialization;
namespace OrderResults.Models.FormRecognizer
{

    public class Span3
    {
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }

}