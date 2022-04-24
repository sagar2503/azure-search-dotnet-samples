using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Hotels{ 

    public class Root
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }

        [JsonPropertyName("value")]
        public List<Value> Value { get; set; }
    }

}