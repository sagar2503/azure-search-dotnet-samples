using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace OrderResults.Models.FormRecognizer
{
    public class AnalyzeResult
    {
        [JsonPropertyName("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("modelId")]
        public string ModelId { get; set; }

        [JsonPropertyName("stringIndexType")]
        public string StringIndexType { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("pages")]
        public List<Page> Pages { get; set; }

        [JsonPropertyName("tables")]
        public List<Table> Tables { get; set; }

        [JsonPropertyName("keyValuePairs")]
        public List<object> KeyValuePairs { get; set; }

        [JsonPropertyName("entities")]
        public List<Entity> Entities { get; set; }

        [JsonPropertyName("styles")]
        public List<object> Styles { get; set; }
    }

}