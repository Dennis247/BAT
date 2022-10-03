namespace BAT.api.Models.Dtos.UserData
{
    public class MergeUserDataDto
    {
        public List<MergeData> MergeData { get; set; }
        public List<string> FieldsForMerging { get; set;}
        public string MergedFileName { get; set; }

    }


    public class MergeData
    {
        public string TableName { get; set; }
        public List<string> TabeleFields { get; set; }
    }
}
