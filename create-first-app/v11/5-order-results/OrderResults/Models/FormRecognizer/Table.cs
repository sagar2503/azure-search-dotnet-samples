using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace OrderResults.Models.FormRecognizer
{

    public class Table
    {
        [JsonPropertyName("rowCount")]
        public int RowCount { get; set; }

        [JsonPropertyName("columnCount")]
        public int ColumnCount { get; set; }

        [JsonPropertyName("cells")]
        public List<Cell> Cells { get; set; }

        [JsonPropertyName("boundingRegions")]
        public List<BoundingRegion> BoundingRegions { get; set; }

        [JsonPropertyName("spans")]
        public List<Span> Spans { get; set; }
    }

}