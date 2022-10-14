using System.Globalization;

namespace BAT.api.Models.Entities
{
    public class UserActivation
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateActivated { get; set; }
        public string HourActivated { get; set; }
       public int WeekActivated { get; set; }
        public string DayOfTheYear { get; set; }
        public string DayOfTheWeek { get; set; }

       
    }


    public class UserActivationDashBoardParameter
    {
        public DateTime startDate { get; set; } 
        public DateTime endDate { get; set; }
      
    }


    public class UserActivationDashBoard
    {
        public List<UserActivationGraph> userActivationGraph { get; set; }
        public int TodayCount { get; set; }
        public List<UserActivationGraph> TodayGraph { get; set; }
        public int ThisWeek { get; set; }
        public List<UserActivationGraph> ThisWeekGraph { get; set; }
        public int ThisMonth {get;set;}
        public List<UserActivationGraph> ThisMonthGarph { get; set; }

    }

    public class UserActivationGraph
    {
        public string Time { get; set; }
        public int UserCount { get; set; }
    }



}
