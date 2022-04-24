using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Hotels{ 

    public class Location
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("crs")]
        public Crs Crs { get; set; }
    }

}