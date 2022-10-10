namespace BAT.api.Utils.Helpers
{
    public class Constants
    {
        public static List<string> Columns = new List<string>
        {
            "firstname",
            "lastname",
            "phonenumber",
            "MobileNumer",
            "state",
            "gender",
            "email",
            "age",
            "DateOfBirth",
            "Occupation",
            "PollingUnit",
            "VotingRAC",
            "VotingLGA",
            "StateOfResidence",
            "LGA",
            "TelcoProvider",
            "MobilePhone",
            "AirtimeUsage",
            "WorkStatus",
            "PVC",
            "IncomeClass",
            "AgeCohorts",
        };


        public static string None = "NONE";
        public static string PENDING = "PENDING";
        public static string APPROVED = "APPROVED";
        public static string REJECTED = "REJECTED";


        //public enum RequestStatus
        //{
        //    None
        //    Pending,
        //    Approved,
        //    Rejected
        //}
    }
}
