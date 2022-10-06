namespace BAT.api.Utils.Helpers
{
    public class StringHelpers
    {
        public static bool IsStringEqual(string value1,string value2)
        {
            return (value1.ToLower().Trim() == value2.ToLower().Trim());
        }


        public static string getHourActivated(int Hour)
        {
            if (Hour >= 0 && Hour < 12)
            {
                return $"{Hour} AM";
            }

            var result = Hour % 12;
            return $"{result} PM";
        }


        public static string FileSize(string fullPath)
        {
            double fileSize = (new FileInfo(fullPath).Length) / (1000);
            return fileSize.ToString();
        }

    }
}
