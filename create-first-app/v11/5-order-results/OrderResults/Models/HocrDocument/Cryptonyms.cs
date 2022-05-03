using System.Text.Json.Serialization;

namespace OrderResults.Models.HocrDocument
{
    public class Cryptonyms
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
