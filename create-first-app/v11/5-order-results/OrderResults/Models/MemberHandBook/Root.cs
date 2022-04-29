using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace OrderResults.Models.MemberHandBook
{

    public class Root
    {
        [JsonPropertyName("@odata.context")]
        public string OdataContext { get; set; }

        [JsonPropertyName("@odata.count")]
        public int OdataCount { get; set; }

        [JsonPropertyName("value")]
        public List<HocrDocument> Value { get; set; }
    }

}