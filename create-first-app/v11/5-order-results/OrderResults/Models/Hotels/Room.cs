using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Hotels{ 

    public class Room
    {
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Description_fr")]
        public string DescriptionFr { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("BaseRate")]
        public double BaseRate { get; set; }

        [JsonPropertyName("BedOptions")]
        public string BedOptions { get; set; }

        [JsonPropertyName("SleepsCount")]
        public int SleepsCount { get; set; }

        [JsonPropertyName("SmokingAllowed")]
        public bool SmokingAllowed { get; set; }

        [JsonPropertyName("Tags")]
        public List<string> Tags { get; set; }
    }

}