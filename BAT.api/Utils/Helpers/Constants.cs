namespace BAT.api.Utils.Helpers
{
    public class Constants
    {
        public static List<string> Columns = new List<string>
        {
            "firstname",
            "lastname",
            "phonenumber",
            "mobilenumber",
            "state",
            "gender",
            "email",
            "age",
            "dateofbirth",
            "occupation",
            "pollingunit",
            "votingrac",
            "votinglga",
            "stateofresidence",
            "lga",
            "telcoprovider",
            "mobilephone",
            "airtimeusage",
            "workstatus",
            "pvc",
            "incomeclass",
            "agecohorts",
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
