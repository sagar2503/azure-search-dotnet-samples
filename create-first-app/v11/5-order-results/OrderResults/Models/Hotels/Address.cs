using System.Text.Json.Serialization; 
namespace Hotels{ 

    public class Address
    {
        [JsonPropertyName("StreetAddress")]
        public string StreetAddress { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("StateProvince")]
        public string StateProvince { get; set; }

        [JsonPropertyName("PostalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }
    }

}