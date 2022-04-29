using System.Text.Json.Serialization;
namespace Hotels
{

    public class Crs
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

}