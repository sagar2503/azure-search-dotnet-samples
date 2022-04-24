using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace OrderResults.Models.FormRecognizer{ 

    public class Page
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("angle")]
        public double Angle { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("words")]
        public List<Word> Words { get; set; }

        [JsonPropertyName("selectionMarks")]
        public List<SelectionMark> SelectionMarks { get; set; }

        [JsonPropertyName("lines")]
        public List<Line> Lines { get; set; }

        [JsonPropertyName("spans")]
        public List<Span> Spans { get; set; }
    }

}