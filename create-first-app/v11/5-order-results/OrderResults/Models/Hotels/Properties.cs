using System.Text.Json.Serialization;
namespace Hotels
{

    public class Properties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}