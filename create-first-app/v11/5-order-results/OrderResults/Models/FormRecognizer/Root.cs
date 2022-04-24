using System.Text.Json.Serialization; 
namespace OrderResults.Models.FormRecognizer{ 

    public class Root
    {
        [JsonPropertyName("analyzeResult")]
        public AnalyzeResult AnalyzeResult { get; set; }
    }

}