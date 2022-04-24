using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderResults.Models.MemberHandBook
{
    public class HocrPages
    {
        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pageImageUrl")]
        public string PageImageUrl { get; set; }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

    }
}
