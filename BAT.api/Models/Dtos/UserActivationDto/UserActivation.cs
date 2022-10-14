using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Dtos.UserActivationDto
{
    public class UserActivationDto
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

    public class AddActivatedUser
    {
        [Required]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
    }


    public class UserActivationRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
    }

}
