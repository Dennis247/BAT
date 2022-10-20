namespace BAT.api.Models.Dtos.UserData
{
    //public class MergeUserDataDto
    //{
    //    public List<MergeData> MergeData { get; set; }
    //    public List<string> FieldsForMerging { get; set;}
    //    public string MergedFileName { get; set; }

    //}


    //public class MergeData
    //{
    //    public  List<int> FileIdsForMerging { get; set;} 
    //    public List<string> TabeleFields { get; set; }
    //}


    public class MergeDataDto
    {
        public List<int> FileIds { get; set; }
        public string RuleId { get; set; }
        public string MergedFileName { get; set; }

    }

    public class MergeRules
    {
        public string RuleId { get; set; }
        public string RuleName { get; set; }



        public static List<MergeRules> GetMergeRules =
            new List<MergeRules> 
            { 
                new MergeRules{
                RuleId = "001",
                RuleName = "Merge Inec with Telco " 
            } 
          };
    }
}
