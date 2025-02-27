﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderResults.Models.HocrDocument
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
