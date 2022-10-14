using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.UserActivationDto;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using BAT.api.Services;
using BAT.api.Utils.Helpers;
using CsvHelper.Excel;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace BAT.api.Services
{

    public interface IUserActivationServices
    {
        Response<string> AddActivatedUsers(AddActivatedUser addActivatedUser);
        Response<List<UserActivationDto>> GetActivatedUsers();
        Response<UserActivationDashBoard> GetUserActivationDashBoard();

        Response<List<UserActivationGraph>> GetActivatedUsersRange(UserActivationRange userActivationRange);

        public byte[] ExportActivatedUsers();
    }
    public class UserActivationServices : IUserActivationServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public UserActivationServices(
            ApplicationDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }



        public Response<string> AddActivatedUsers(AddActivatedUser addActivatedUser)
        {
            //check if user has been 
            var existing = _context.UserActivations.FirstOrDefault(x => x.Name.ToLower().Trim() == addActivatedUser.Name.ToLower().Trim()
            && x.PhoneNumber.Trim() == addActivatedUser.PhoneNumber.Trim());

            if (existing == null)
            {
                _context.UserActivations.Add(new UserActivation
                {
                    PhoneNumber = addActivatedUser.PhoneNumber,
                    DateActivated = DateTime.UtcNow,
                    Name = addActivatedUser.Name,
                    HourActivated = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                    WeekActivated = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.UtcNow, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                    DayOfTheWeek = DateTime.UtcNow.DayOfWeek.ToString(),
                    DayOfTheYear = DateTime.Now.DayOfYear.ToString(),
                });

                _context.SaveChanges();
            }

            return new Response<string>
            {
                Data = "",
                Message = "Your souvenir request was successful",
                Succeeded = true
            };
        }

  
     
        public Response<List<UserActivationDto>> GetActivatedUsers()
        {
            var activations = _context.UserActivations.ToList();
            var userActivationsToReturn = _mapper.Map<List<UserActivationDto>>(activations);
            return new Response<List<UserActivationDto>>
            {
                Data = userActivationsToReturn,
                Message = "Sucessful",
                Succeeded = true
            };
        }

        public Response<List<UserActivationGraph>> GetActivatedUsersRange(UserActivationRange userActivationRange)
        {
            var rangeResult = _context.UserActivations.Where(x => x.DateActivated >= userActivationRange.StartDate && x.DateActivated <= userActivationRange.EndDate);
            var results = from u in rangeResult
                          group u by u.HourActivated into g
                          select new { time = g.Key, Count = g.ToList().Count() };

            List<UserActivationGraph> list = new List<UserActivationGraph>();
            foreach (var item in results)
            {
                list.Add(new UserActivationGraph { Time = item.time.ToString(), UserCount = item.Count });
            }

            return new Response<List<UserActivationGraph>>
            {
                Data = list,
                Message = "sucessufl",
                Succeeded = true

            };
        }

        public Response<UserActivationDashBoard> GetUserActivationDashBoard()
        {
            var weekOfTheYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            UserActivationDashBoard userActivationDashBoard = new UserActivationDashBoard
            {
                ThisWeekGraph = new List<UserActivationGraph>(),
                ThisMonthGarph  = new List<UserActivationGraph>(),
                TodayGraph = new List<UserActivationGraph>(),
            };

            int TodayCount = _context.UserActivations.Count(x => x.DateActivated.Date == DateTime.UtcNow.Date);
            int ThisWeekCount = _context.UserActivations.Count(x => x.WeekActivated == weekOfTheYear);
            int ThisMonthCount = _context.UserActivations.Count(x => x.DateActivated.Date.Month == DateTime.UtcNow.Month && x.DateActivated.Date.Year == DateTime.UtcNow.Year);

            var results = from u in _context.UserActivations
                          group u by u.HourActivated into g
                          select new { time = g.Key, Count = g.ToList().Count() };

            List<UserActivationGraph> list = new List<UserActivationGraph>
            {
                   new  UserActivationGraph { Time = "12 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "1 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "2 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "3 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "4 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "5 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "6 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "7 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "8 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "9 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "10 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "11 AM", UserCount = 0 },
                    new  UserActivationGraph { Time = "12 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "1 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "2 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "1 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "2 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "3 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "4 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "5 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "6 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "7 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "8 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "9 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "10 PM", UserCount = 0 },
                    new  UserActivationGraph { Time = "11 PM", UserCount = 0 },
            };


            foreach (var item in results)
            {
                list.Add(new UserActivationGraph { Time = item.time.ToString(), UserCount = item.Count });

                var itemToSet = list.FirstOrDefault(x => x.Time == item.time);
                if (itemToSet != null)
                {
                    itemToSet.Time = item.time;
                    itemToSet.UserCount = item.Count;
                }


            }


            var TodayGarphList = from u in _context.UserActivations.Where(x => x.DateActivated.Date == DateTime.Today)
                               group u by u.HourActivated into g
                               select new { time = g.Key, Count = g.ToList().Count() };

            foreach (var item in TodayGarphList)
            {
                userActivationDashBoard.TodayGraph.Add(new UserActivationGraph { Time = item.time, UserCount = item.Count });
            }



            var weekGarphList = from u in _context.UserActivations.Where(x => x.WeekActivated == weekOfTheYear)
                                 group u by u.DayOfTheWeek into g
                                 select new { Day = g.Key, Count = g.ToList().Count() };

            foreach (var item in weekGarphList)
            {
                userActivationDashBoard.ThisWeekGraph.Add(new UserActivationGraph { Time = item.Day, UserCount = item.Count });
            }



            var monthGraphList = from u in _context.UserActivations.Where(x => x.DateActivated.Date.Month 
                                 == DateTime.UtcNow.Month && x.DateActivated.Date.Year == DateTime.UtcNow.Year)
                                group u by u.DayOfTheYear into g
                                select new { Day = g.Key, Count = g.ToList().Count() };

            foreach (var item in monthGraphList)
            {
                userActivationDashBoard.ThisMonthGarph.Add(new UserActivationGraph { Time = item.Day, UserCount = item.Count });
            }



            userActivationDashBoard.ThisMonth = ThisMonthCount;
            userActivationDashBoard.ThisWeek = ThisWeekCount;
            userActivationDashBoard.TodayCount = TodayCount;
            userActivationDashBoard.userActivationGraph = list;


            return new Response<UserActivationDashBoard>
            {
                Data =userActivationDashBoard,
                Succeeded = true,
                Message = ""

            };
        }

  

        public byte[] ExportActivatedUsers()
        {
            {
                using var memoryStream = new MemoryStream();

                {
                    using var excelWriter = new ExcelWriter(memoryStream, CultureInfo.InvariantCulture);
                    excelWriter.WriteField("Name");
                    excelWriter.WriteField("Phone Number");
                    excelWriter.WriteField("Date Activated");
                    excelWriter.NextRecord();

                    var dataToExport = _context.UserActivations.ToList();

                    foreach (var item in dataToExport)
                    {
                        excelWriter.WriteField(@$"'{item.Name}");
                        excelWriter.WriteField(@$"'{item.PhoneNumber}");
                        excelWriter.WriteField(@$"'{item.DateActivated.ToLongDateString()}");
                        excelWriter.NextRecord();
                    }
                    memoryStream.Position = 0;
                }

                return memoryStream.ToArray();
            }
        }

    }
}
