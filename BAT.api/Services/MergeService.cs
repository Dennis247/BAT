using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Models.Entities;
using BAT.api.Models.enums;
using BAT.api.Models.Response;
using BAT.api.Utils.Filters;
using BAT.api.Utils.Helpers;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Excel;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace BAT.api.Services
{
    public interface IMergeService
    {
     
        Task<Response<int>> MergeUserData(MergeDataDto mergeUserDataDto, int AdminId);
        Response<List<MergeRules>> GetAllMergeRules();

    }

    public class MergeService : IMergeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IUriService _uriService;
        private readonly IDapperDbConnection _dapperDbConnection;

        public MergeService(
             ApplicationDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
             IUriService uriService,
              IDapperDbConnection dapperDbConnection)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _uriService = uriService;
            _context = context;
            _dapperDbConnection = dapperDbConnection;
        }

        public Response<List<MergeRules>> GetAllMergeRules()
        {
            return new Response<List<MergeRules>>
            {
                Data = MergeRules.GetMergeRules,
                Message = "sucessful",
                Succeeded = true
            };
        }

        public async Task<Response<int>> MergeUserData(MergeDataDto mergeUserDataDto, int AdminId)
        {

            var allFIleUploads = _context.FileUploads.ToList();
            List<List<UserData>> dataForMerging = new List<List<UserData>>();

            //check that the file for merging are both valid
            foreach (var item in mergeUserDataDto.FileIds)
            {
                var userUploadExist = allFIleUploads.FirstOrDefault(x => x.Id == item);
                if (userUploadExist == null)
                    throw new AppException($"File with Id {item} does not exist");
                var dataForMerge = _context.UserDatas.Where(x => x.FileId == item).ToList();
                dataForMerging.Add(dataForMerge);


            }

            var data1 = dataForMerging[0];
            var data2 = dataForMerging[1];
            dynamic result;
            int count = 0;

            if (mergeUserDataDto.RuleId == "001")
            {
                var data = from dt1 in data1
                         join dt2 in data2
                              on dt1.MobileNumber equals dt2.MobileNumber
                         select new
                         {
                             dt1.FirstName,
                             dt1.LastName,
                             dt2.Gender,
                             dt1.MobileNumber,
                             dt1.TelcoProvider,
                             dt2.DateOfBirth,
                             dt1.Age,
                             dt2.StateofOrigin,
                             dt1.Address,
                             dt1.AirtimeUsage,
                             dt1.IncomeClass,
                             dt1.AgeCohorts,
                             dt2.Occupation,
                             dt2.WorkStatus,
                             dt2.RAC,
                             dt2.LGA,
                             dt2.State
                         };
                count = data.Count();
                result = data;
            }
            else
            {
                var data = from dt1 in data1
                         join dt2 in data2
                              on dt1.MobileNumber equals dt2.MobileNumber
                         select new
                         {
                             dt1.FirstName,
                             dt1.LastName,
                             dt2.Gender,
                             dt1.MobileNumber,
                             dt1.TelcoProvider,
                             dt2.DateOfBirth,
                             dt1.Age,
                             dt2.StateofOrigin,
                             dt1.Address,
                             dt1.AirtimeUsage,
                             dt1.IncomeClass,
                             dt1.AgeCohorts,
                             dt2.Occupation,
                             dt2.WorkStatus,
                             dt2.RAC,
                             dt2.LGA,
                             dt2.State
                         };

                count = data.Count();
                result = data;
            }

          

          

            var fileFields = JsonConvert.SerializeObject(new List<string> {
                        "PhoneNumber", "FirstName", "LastName", "Address", "Age", "AgeCohorts", "AirtimeUsage", "DateOfBirth", "Gender", "LGA", "Occupation", "State",
                        "StateofOrigin", "WorkStatus", "RAC", "TelcoProvider"
                    });


            FileUpload fileUpload = new FileUpload
            {
                IsInPreviewMode = false,
                IsMerged = true,
                MergedBy = AdminId,
                DateMerged = DateTime.UtcNow,
                HourMerged = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                FileSize = "",
                FileName = mergeUserDataDto.MergedFileName + ".xlsx",
                Fields = fileFields,
                UploadedBy = AdminId,
                TotalRecordCount = count,
                DateSaved = DateTime.UtcNow,
                HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                DateUploaded = DateTime.UtcNow,
                FileType = ".xlsx",
                DownloadUrl = ""

            };
            try
            {
                _context.FileUploads.Add(fileUpload);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            List<UserData> userListForSeeding = new List<UserData>();
            foreach (var item in result)
            {
                UserData userData = new UserData
                {
                    PhoneNumber = item.MobileNumber,
                    MobileNumber = item.MobileNumber,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Address = item.Address,
                    Age = item.Age,
                    AgeCohorts = item.AgeCohorts,
                    AirtimeUsage = item.AirtimeUsage,
                    Created = DateTime.Now,
                    CreatedBy = AdminId,
                    DateOfBirth = item.DateOfBirth,
                    Gender = item.Gender,
                    LGA = item.LGA,
                    Occupation = item.Occupation,
                    State = item.State,
                    StateofOrigin = item.StateofOrigin,
                    WorkStatus = item.WorkStatus,
                    RAC = item.RAC,
                    TelcoProvider = item.TelcoProvider,
                    FileId = fileUpload.Id,
                    FileFields = fileFields


                };
                userListForSeeding.Add(userData);
            }

            _context.UserDatas.AddRange(userListForSeeding);
            _context.SaveChanges();


            return new Response<int>
            {
                Data = fileUpload.Id,
                Message = "Merge Sucessful",
                Succeeded = true
            };



        }

    }
}
