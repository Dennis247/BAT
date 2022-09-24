namespace BAT.api.Utils.Helpers
{
    public class StringHelpers
    {
        public static bool IsStringEqual(string value1,string value2)
        {
            return (value1.ToLower().Trim() == value2.ToLower().Trim());
        }
    }
}
