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
                ProcessedDataGraph = new List<UserReportGraph>(),
                UploadedDataGraph = new List<UserReportGraph>(),
            };

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
                UploadedData=0,
                ProcessedDataGraph= new List<UserReportGraph>(),
                UploadedDataGraph = new List<UserReportGraph> ()
            };

        

            userReportDashBoard.UploadedData = _context.FileUploads.Count();
            userReportDashBoard.ProcessedData = _context.ProcessedFileDetails.Count();
            userReportDashBoard.ReportCreated = _context.AnalyzeDatas.Count();

            var uploadedData = from u in _context.FileUploads
                                 group u by u.HourUploaded into g
                                select new { time = g.Key, Count = g.ToList().Count() };

            foreach (var item in uploadedData)
            {
                userReportDashBoard.UploadedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }

            var processedData = from u in _context.FileUploads.Where(x=>x.IsProcessed)
                               group u by u.HourUploaded into g
                               select new { time = g.Key, Count = g.ToList().Count() };



            foreach (var item in processedData)
            {
                userReportDashBoard.ProcessedDataGraph.Add(new UserReportGraph { Hour = item.time, Count = item.Count });
            }

            //group uploade data by time 


            //group processed data by time

            return new Response<UserReportDashBoard>
            {
                Data = userReportDashBoard,
                Message = "",
                Succeeded = true
            };
        }
    }
}
