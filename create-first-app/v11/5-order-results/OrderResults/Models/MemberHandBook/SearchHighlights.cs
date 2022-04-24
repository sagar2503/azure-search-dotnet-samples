using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderResults.Models.MemberHandBook
{
    public class SearchHighlights
    {
        [JsonPropertyName("text")]
        public List<string> Text { get; set; }
    }
}
