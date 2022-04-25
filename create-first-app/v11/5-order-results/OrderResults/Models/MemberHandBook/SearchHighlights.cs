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

        /// <summary>
        /// Override string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this == null || this.Text == null)
                return string.Empty;
            string joinedText = string.Join(",", Text.ToArray());
            joinedText = joinedText.Replace("<em>", "<mark>");
            joinedText = joinedText.Replace("</em>", "</mark>");
            return joinedText;
        }
    }
}
