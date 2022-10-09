using System.Globalization;
using System.Reflection;

namespace BAT.api.Utils.Helpers
{
    public class StringHelpers
    {
        public static bool IsStringEqual(string value1,string value2)
        {
            return (value1.ToLower().Trim() == value2.ToLower().Trim());
        }

        public static bool IsBase64String(string base64String)
        {
           
            // Credit: oybek http://stackoverflow.com/users/794764/oybek
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                var result = Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                // Handle the exception
                return false;
            }

   
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


        public static string ToTitleCase(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }

    }



   public class GenericHelper
    {
        public static List< T > SortData<T>(List<T> data, string sortField, string sortOrder)
        {
            try
            {
                string SortField = sortField;
                string SortOrder = sortOrder;


                if (string.IsNullOrEmpty(sortField))
                {
                    SortField = "Id";
                    SortOrder = "asc";
                }

                if (string.IsNullOrEmpty(sortOrder))
                {
                    SortOrder = "asc";
                }

                SortField = StringHelpers.ToTitleCase(SortField);

                var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var propertyInfo = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(SortField, StringComparison.InvariantCultureIgnoreCase));

                if (SortOrder == "asc")
                {
                    data = data.OrderBy(s => propertyInfo.GetValue(s, null)).ToList();
                }
                else
                {
                    data = data.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();
                }
                return data;
            }
            catch (Exception)
            {

                return data;
            }


        }


  

    }

}
