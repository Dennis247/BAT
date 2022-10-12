using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using static BAT.api.Models.Dtos.UserData.UserImportlDataDto;

namespace BAT.api.Services
{
    public interface IUserDataService
    {
        Response<UserReportDashBoard> GetUserDataDashBoard();

        Response<DashBoardRageSearch> GetDashBoardRangeSearch(UserDashBoardRange userDashBoardRange);
    }


    public class UserDataService : IUserDataService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public UserDataService(
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

        public Response<DashBoardRageSearch> GetDashBoardRangeSearch(UserDashBoardRange userDashBoardRange)
        {
            DashBoardRageSearch dashBoardRageSearch = new DashBoardRageSearch
            {
                ProcessedDataGraph = new List<UserReportGraph>
                {
                    new  UserReportGraph { Hour = "12 AM", Count = 0 },
                    new  UserReportGraph { Hour = "1 AM", Count = 0 },
                    new  UserReportGraph { Hour = "2 AM", Count = 0 },
                    new  UserReportGraph { Hour = "3 AM", Count = 0 },
                    new  UserReportGraph { Hour = "4 AM", Count = 0 },
                    new  UserReportGraph { Hour = "5 AM", Count = 0 },
                    new  UserReportGraph { Hour = "6 AM", Count = 0 },
                    new  UserReportGraph { Hour = "7 AM", Count = 0 },
                    new  UserReportGraph { Hour = "8 AM", Count = 0 },
                    new  UserReportGraph { Hour = "9 AM", Count = 0 },
                    new  UserReportGraph { Hour = "10 AM", Count = 0 },
                    new  UserReportGraph { Hour = "11 AM", Count = 0 },
                    new  UserReportGraph { Hour = "12 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "3 PM", Count = 0 },
                    new  UserReportGraph { Hour = "4 PM", Count = 0 },
                    new  UserReportGraph { Hour = "5 PM", Count = 0 },
                    new  UserReportGraph { Hour = "6 PM", Count = 0 },
                    new  UserReportGraph { Hour = "7 PM", Count = 0 },
                    new  UserReportGraph { Hour = "8 PM", Count = 0 },
                    new  UserReportGraph { Hour = "9 PM", Count = 0 },
                    new  UserReportGraph { Hour = "10 PM", Count = 0 },
                    new  UserReportGraph { Hour = "11 PM", Count = 0 },

                },

                UploadedDataGraph = new List<UserReportGraph>
                {
                    new  UserReportGraph { Hour = "12 AM", Count = 0 },
                    new  UserReportGraph { Hour = "1 AM", Count = 0 },
                    new  UserReportGraph { Hour = "2 AM", Count = 0 },
                    new  UserReportGraph { Hour = "3 AM", Count = 0 },
                    new  UserReportGraph { Hour = "4 AM", Count = 0 },
                    new  UserReportGraph { Hour = "5 AM", Count = 0 },
                    new  UserReportGraph { Hour = "6 AM", Count = 0 },
                    new  UserReportGraph { Hour = "7 AM", Count = 0 },
                    new  UserReportGraph { Hour = "8 AM", Count = 0 },
                    new  UserReportGraph { Hour = "9 AM", Count = 0 },
                    new  UserReportGraph { Hour = "10 AM", Count = 0 },
                    new  UserReportGraph { Hour = "11 AM", Count = 0 },
                    new  UserReportGraph { Hour = "12 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "3 PM", Count = 0 },
                    new  UserReportGraph { Hour = "4 PM", Count = 0 },
                    new  UserReportGraph { Hour = "5 PM", Count = 0 },
                    new  UserReportGraph { Hour = "6 PM", Count = 0 },
                    new  UserReportGraph { Hour = "7 PM", Count = 0 },
                    new  UserReportGraph { Hour = "8 PM", Count = 0 },
                    new  UserReportGraph { Hour = "9 PM", Count = 0 },
                    new  UserReportGraph { Hour = "10 PM", Count = 0 },
                    new  UserReportGraph { Hour = "11 PM", Count = 0 },

                }

            };

            var uploadedData = from u in _context.FileUploads.Where(x=>x.DateUploaded >= userDashBoardRange.StartDate
                               && x.DateUploaded<=userDashBoardRange.EndDate)
                               group u by u.HourUploaded into g
                               select new { time = g.Key, Count = g.ToList().Count()};

            foreach (var item in uploadedData)
            {
                var itemToSet = dashBoardRageSearch.UploadedDataGraph.FirstOrDefault(x => x.Hour == item.time);
                if (itemToSet != null)
                {
                    itemToSet.Hour = item.time;
                    itemToSet.Count = item.Count;
                }


                //   userReportDashBoard.UploadedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }



            var processedData = from u in _context.ProcessedFileDetails.
                                Where(x => x.DateProcessed
                                >= userDashBoardRange.StartDate
                               && x.DateProcessed <= userDashBoardRange.EndDate)
                                group u by u.HourProcessed into g
                                select new { time = g.Key, Count = g.ToList().Count()};

            foreach (var item in processedData)
            {
                var itemToSet = dashBoardRageSearch.UploadedDataGraph.FirstOrDefault(x => x.Hour == item.time);
                if (itemToSet != null)
                {
                    itemToSet.Hour = item.time;
                    itemToSet.Count = item.Count;
                }

                // userReportDashBoard.ProcessedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }


            return new Response<DashBoardRageSearch>
            {
                Data = dashBoardRageSearch,
                Message = "sucessful",
                Succeeded = true
            };
        }

        public Response<UserReportDashBoard> GetUserDataDashBoard()
        {
            UserReportDashBoard userReportDashBoard = new UserReportDashBoard
            {
                ProcessedData = 0,
                ErrorsGenerated = 0,
                ReportCreated = 0,
                UploadedData = 0,
               
                ProcessedDataGraph = new List<UserReportGraph>
                {
                    new  UserReportGraph { Hour = "12 AM", Count = 0 },
                    new  UserReportGraph { Hour = "1 AM", Count = 0 },
                    new  UserReportGraph { Hour = "2 AM", Count = 0 },
                    new  UserReportGraph { Hour = "3 AM", Count = 0 },
                    new  UserReportGraph { Hour = "4 AM", Count = 0 },
                    new  UserReportGraph { Hour = "5 AM", Count = 0 },
                    new  UserReportGraph { Hour = "6 AM", Count = 0 },
                    new  UserReportGraph { Hour = "7 AM", Count = 0 },
                    new  UserReportGraph { Hour = "8 AM", Count = 0 },
                    new  UserReportGraph { Hour = "9 AM", Count = 0 },
                    new  UserReportGraph { Hour = "10 AM", Count = 0 },
                    new  UserReportGraph { Hour = "11 AM", Count = 0 },
                    new  UserReportGraph { Hour = "12 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "3 PM", Count = 0 },
                    new  UserReportGraph { Hour = "4 PM", Count = 0 },
                    new  UserReportGraph { Hour = "5 PM", Count = 0 },
                    new  UserReportGraph { Hour = "6 PM", Count = 0 },
                    new  UserReportGraph { Hour = "7 PM", Count = 0 },
                    new  UserReportGraph { Hour = "8 PM", Count = 0 },
                    new  UserReportGraph { Hour = "9 PM", Count = 0 },
                    new  UserReportGraph { Hour = "10 PM", Count = 0 },
                    new  UserReportGraph { Hour = "11 PM", Count = 0 },

                },

                UploadedDataGraph = new List<UserReportGraph>
                {
                    new  UserReportGraph { Hour = "12 AM", Count = 0 },
                    new  UserReportGraph { Hour = "1 AM", Count = 0 },
                    new  UserReportGraph { Hour = "2 AM", Count = 0 },
                    new  UserReportGraph { Hour = "3 AM", Count = 0 },
                    new  UserReportGraph { Hour = "4 AM", Count = 0 },
                    new  UserReportGraph { Hour = "5 AM", Count = 0 },
                    new  UserReportGraph { Hour = "6 AM", Count = 0 },
                    new  UserReportGraph { Hour = "7 AM", Count = 0 },
                    new  UserReportGraph { Hour = "8 AM", Count = 0 },
                    new  UserReportGraph { Hour = "9 AM", Count = 0 },
                    new  UserReportGraph { Hour = "10 AM", Count = 0 },
                    new  UserReportGraph { Hour = "11 AM", Count = 0 },
                    new  UserReportGraph { Hour = "12 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "1 PM", Count = 0 },
                    new  UserReportGraph { Hour = "2 PM", Count = 0 },
                    new  UserReportGraph { Hour = "3 PM", Count = 0 },
                    new  UserReportGraph { Hour = "4 PM", Count = 0 },
                    new  UserReportGraph { Hour = "5 PM", Count = 0 },
                    new  UserReportGraph { Hour = "6 PM", Count = 0 },
                    new  UserReportGraph { Hour = "7 PM", Count = 0 },
                    new  UserReportGraph { Hour = "8 PM", Count = 0 },
                    new  UserReportGraph { Hour = "9 PM", Count = 0 },
                    new  UserReportGraph { Hour = "10 PM", Count = 0 },
                    new  UserReportGraph { Hour = "11 PM", Count = 0 },

                }
            };



            userReportDashBoard.UploadedData = _context.FileUploads.Count();
            userReportDashBoard.ProcessedData = _context.ProcessedFileDetails.Count();
            userReportDashBoard.ReportCreated = _context.AnalyzeDatas.Count();
            userReportDashBoard.ErrorsGenerated = _context.UploadErrors.Count();

            var uploadedData = from u in _context.FileUploads.Where(x=>x.DateUploaded.Date == DateTime.Today)
                               group u by u.HourUploaded into g
                               select new { time = g.Key, Count = g.ToList().Count() };
            foreach (var item in uploadedData)
            {
                var itemToSet = userReportDashBoard.UploadedDataGraph.FirstOrDefault(x => x.Hour == item.time);
                if(itemToSet != null)
                {
                    itemToSet.Hour = item.time;
                    itemToSet.Count =item.Count;
                }


             //   userReportDashBoard.UploadedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }

         
            
            var processedData = from u in _context.ProcessedFileDetails
                                .Where(x => x.DateProcessed.Date == DateTime.Today)group u by u.HourProcessed into g
                                select new { time = g.Key, Count = g.ToList().Count() };
            foreach (var item in processedData)
            {
                var itemToSet = userReportDashBoard.UploadedDataGraph.FirstOrDefault(x => x.Hour == item.time);
                if (itemToSet != null)
                {
                    itemToSet.Hour = item.time;
                    itemToSet.Count = item.Count;
                }

                // userReportDashBoard.ProcessedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }


            return new Response<UserReportDashBoard>
            {
                Data = userReportDashBoard,
                Message = "",
                Succeeded = true
            };
        }
    }
}
