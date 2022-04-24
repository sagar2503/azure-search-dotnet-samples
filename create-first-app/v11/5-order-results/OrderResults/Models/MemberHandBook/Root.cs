using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace OrderResults.Models.MemberHandBook
{ 

    public class Root
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }

        [JsonPropertyName("@odata.count")]
        public int OdataCount { get; set; }

        [JsonPropertyName("value")]
        public List<MemberHandbook> Value { get; set; }
    }

}