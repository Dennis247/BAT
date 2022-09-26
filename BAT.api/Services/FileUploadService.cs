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
using CsvHelper.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Net.Http.Headers;

namespace BAT.api.Services
{
    public interface IFileUploadService
    {
        PagedResponse<List<FileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route);
        Response<string> UploadUserData(IFormFile formFile, int AdminId);
        PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IUriService _uriService;

        public FileUploadService(
             ApplicationDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
             IUriService uriService)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _uriService = uriService;
            _context = context;
        }

        public PagedResponse<List<FileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData)
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();
            var totalRecords = _context.FileUploads.Count();
            var filesUploadToReturn = _mapper.Map<List<FileUploadDto>>(pagedData);


            var pagedReponse = PaginationHelper.CreatePagedReponse<FileUploadDto>(filesUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public Response<string> UploadUserData(IFormFile formFile, int AdminId)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                throw new AppException("File cannot be null or empty");
            }

            string fileExtension = Path.GetExtension(formFile.FileName);

            if (!fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                !fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                throw new AppException("Only .xlsx and .csv format is supported");
            }

            //Todo upload large file to path and seed the file content to database

            var folderName = Path.Combine("AppUploads", "UserData");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var filePath = Path.Combine(folderName, fileName);
            filePath = filePath.Replace("\\", "//");
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }



            FileUpload fileUpload = new FileUpload
            {
                UploadedBy = AdminId,
                DateUploaded = DateTime.UtcNow,
                FileName = formFile.FileName,
                FileType = fileExtension,
                DownloadUrl = filePath
            };

            _context.FileUploads.Add(fileUpload);
            _context.SaveChanges();


            //Todo read file from excel and bulk insert into db
            using var reader = new CsvReader(new ExcelParser(fullPath));
            var userDataToSave = reader.GetRecords<UserData>();

            DataTable table = new DataTable();
            table.TableName = "UserData";

            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Location", typeof(string));
            table.Columns.Add("FileId", typeof(int));

            foreach (var userData in userDataToSave)
            {
                var row = table.NewRow();
                row[nameof(userData.FirstName)] = userData.FirstName;
                row[nameof(userData.FirstName)] = userData.LastName;
                row[nameof(userData.FirstName)] = userData.Email;
                row[nameof(userData.FirstName)] = userData.State;
                row[nameof(userData.FirstName)] = userData.Location;
                row[nameof(userData.FileId)] = fileUpload;
                table.Rows.Add(row);
            }

            _context.BulkInsert(table);


            return new Response<string>
            {
                Data = "",
                Message = "File Upload sucessfull",
                Succeeded = true,

            };
        }

        public PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route)
        {
            var userData = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            if (userData == null)
                throw new AppException("Inavlid file Id");

            //get file that holds all the data and read the data into a list

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            List<UserData> pagedData = _context.UserDatas.Where(x => x.FileId == FileId)
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();
            var totalRecords = _context.FileUploads.Count();
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);


            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDataDto>(userDataToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;



        }
    }
}
