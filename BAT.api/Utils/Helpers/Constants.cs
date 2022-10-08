namespace BAT.api.Utils.Helpers
{
    public class Constants
    {
        public static List<string> Columns = new List<string>
        {
            "firstname",
            "lastname",
            "phonenumber",
            "state",
            "gender",
            "email",
            "age"
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
