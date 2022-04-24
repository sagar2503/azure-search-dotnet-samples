using System.Text.Json.Serialization; 
using System.Collections.Generic; 
using System; 
namespace Hotels{ 

    public class Value
    {
        [JsonPropertyName("@search.score")]
        public int SearchScore { get; set; }

        [JsonPropertyName("HotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("HotelName")]
        public string HotelName { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Description_fr")]
        public string DescriptionFr { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("Tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("ParkingIncluded")]
        public bool ParkingIncluded { get; set; }

        [JsonPropertyName("LastRenovationDate")]
        public DateTime LastRenovationDate { get; set; }

        [JsonPropertyName("Rating")]
        public double Rating { get; set; }

        [JsonPropertyName("Location")]
        public Location Location { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }

        [JsonPropertyName("Rooms")]
        public List<Room> Rooms { get; set; }
    }

}