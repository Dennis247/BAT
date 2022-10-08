namespace BAT.api.Models.Dtos.Analyze
{
    public class AnalyzeDto
    {
        public string WidgetType { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }
        public dynamic Extras { get; set; }
    }


    public class AnalyzeResponse
    {

        public List<Data> data { get; set; }
        public string WidgetType { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }
        public int UploadedFileCount { get; set; }
        public int ProcessedFileCount { get; set; }
        public dynamic Extras { get; set; }

    }

    public class AnalyzeResponseResult
    {
        public int AnalyzeId { get; set; }
        public DateTime Date { get; set; }
        public List<AnalyzeResponse> AnalyzeResponses { get; set; }
        public string Objective { get; set; }
        public int AnalyzedBy { get; set; }
        public string AnalyzedByName { get; set; }
    }

    public class ExportAnalyzedData
    {
        public AnalyzeResponseResult analyzedData { get; set; }
        public string DownloadUrl { get; set; }
    }


    public class Data
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }

    public class AnalyzeRequest
    {
        public int FileId { get; set; }
        public string Objective { get; set; }

        public List<AnalyzeDto> AnalyzeDtos { get; set; }
}


}
