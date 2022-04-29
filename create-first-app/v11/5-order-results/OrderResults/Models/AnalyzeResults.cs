using System.Collections.Generic;

namespace OrderResults.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Span
    {
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Word
    {
        public string content { get; set; }
        public List<double> boundingBox { get; set; }
        public double confidence { get; set; }
        public Span span { get; set; }
    }

    public class SelectionMark
    {
        public string state { get; set; }
        public List<double> boundingBox { get; set; }
        public double confidence { get; set; }
        public Span span { get; set; }
    }

    public class Span3
    {
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Line
    {
        public string content { get; set; }
        public List<double> boundingBox { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Page
    {
        public int pageNumber { get; set; }
        public double angle { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string unit { get; set; }
        public List<Word> words { get; set; }
        public List<SelectionMark> selectionMarks { get; set; }
        public List<Line> lines { get; set; }
        public List<Span> spans { get; set; }
    }

    public class BoundingRegion
    {
        public int pageNumber { get; set; }
        public List<double> boundingBox { get; set; }
    }

    public class Cell
    {
        public string kind { get; set; }
        public int rowIndex { get; set; }
        public int columnIndex { get; set; }
        public int rowSpan { get; set; }
        public int columnSpan { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Table
    {
        public int rowCount { get; set; }
        public int columnCount { get; set; }
        public List<Cell> cells { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Entity
    {
        public string category { get; set; }
        public string subCategory { get; set; }
        public string content { get; set; }
        public List<BoundingRegion> boundingRegions { get; set; }
        public double confidence { get; set; }
        public List<Span> spans { get; set; }
    }

    public class AnalyzeResult
    {
        public string apiVersion { get; set; }
        public string modelId { get; set; }
        public string stringIndexType { get; set; }
        public string content { get; set; }
        public List<Page> pages { get; set; }
        public List<Table> tables { get; set; }
        public List<object> keyValuePairs { get; set; }
        public List<Entity> entities { get; set; }
        public List<object> styles { get; set; }
    }

    public class Root
    {
        public AnalyzeResult analyzeResult { get; set; }
    }


}
