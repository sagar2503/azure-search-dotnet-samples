using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderResults.Models.MemberHandBook
{
    public class Cryptonyms
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
