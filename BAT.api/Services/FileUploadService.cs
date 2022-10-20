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
    public interface IFileUploadService
    {
        PagedResponse<List<UserFileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route, Account account);
        public PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route);
        Task<Response<int>> MergeUserData(MergeDataDto mergeUserDataDto, int AdminId);

        Task<Response<int>> PreviewFile(IFormFile formFile, Account account);

        PagedResponse<List<FileUploadDto>> GetUserPreviewedFiles(PaginationFilter filter, Account account, string route);

        Response<string> SavePreviewedFile(int FileId);

        PagedResponse<List<UserDataDto>> ViewFileContents(int FileId, PaginationFilter filter, string route);

        Response<string> DeleteFile(int FileId);
         Task<Response<string>> UpdateFile(UpdateFile updateFile, Account account);

        Task<Response<int>> ProcessFile(ProcessFileRequest processFileRequest, Account account);

        PagedResponse<List<UserProcessedFileDetailsDto>> GetProcessedFiles(PaginationFilter filter, string route, Account Account);

        PagedResponse<List<UserDataDto>> ViewProcessedFileContents(int FileId, PaginationFilter filter, string route);


        public Response<ProcessedFileDetailsDto> GetProcessedFileById(int Id);

        PagedResponse<List<UploadError>> GetUploadedErrors(PaginationFilter filter, string route, Account Account);

        public DownloadResponse DownloadFileUsingFields(int FileId);


        public DownloadResponse DownloadFile(int FileId);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IUriService _uriService;
        private readonly IDapperDbConnection _dapperDbConnection;

        public FileUploadService(
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

        public PagedResponse<List<UserFileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route, Account account)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            int totalRecords = 0;
            var pagedData = new List<FileUpload>();
            if (account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode && !x.IsProcessed)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();

                totalRecords = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode && !x.IsProcessed).Count();
            }
            else
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode && x.UploadedBy == account.Id && !x.IsProcessed)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();

                totalRecords = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode && x.UploadedBy == account.Id && !x.IsProcessed).Count();
            }


            var filesUploadToReturn = _mapper.Map<List<UserFileUploadDto>>(pagedData);
            filesUploadToReturn = GenericHelper.SortData(filesUploadToReturn, filter.sortBy, filter.sortOrder);


            var pagedReponse = PaginationHelper.CreatePagedReponse<UserFileUploadDto>(filesUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

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

            var result = from dt1 in data1
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

            int count = result.Count();

            var fileFields = JsonConvert.SerializeObject(new List<string> {
                        "PhoneNumber", "MobileNumber", "FirstName", "LastName", "Address", "Age", "AgeCohorts", "AirtimeUsage", "DateOfBirth", "Gender", "LGA", "Occupation", "State",
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
                FileName = mergeUserDataDto.MergedFileName+ ".xlsx",
                Fields = fileFields,
                UploadedBy = AdminId,
                TotalRecordCount = count,
                DateSaved = DateTime.UtcNow,
                HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                DateUploaded = DateTime.UtcNow,
                FileType = ".xlsx",
                DownloadUrl=""

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

        private static Expression<Func<T, string>> GetExpression<T>(string property)
        {
            var userdata = Expression.Parameter(typeof(T), "x");
            var menuProperty = Expression.PropertyOrField(userdata, property);
            var lambda = Expression.Lambda<Func<T, string>>(menuProperty, userdata);

            return lambda;
        }



        public PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route)
        {
            List<int> mergedids = new List<int>();
            List<UserData> pagedData = new List<UserData>();
            var userData = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            int count = 0;
            if (userData == null)
                throw new AppException("Inavlid file Id");



            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            pagedData = _context.UserDatas.Where(x => x.FileId == FileId)
       .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
       .Take(validFilter.PageSize)
       .ToList();
            count = _context.UserDatas.Where(x => x.FileId == FileId).Count();


            var totalRecords = count;
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);
            userDataToReturn = GenericHelper.SortData(userDataToReturn, filter.sortBy, filter.sortOrder);

            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDataDto>(userDataToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;



        }

        public async Task<Response<int>> PreviewFile(IFormFile formFile, Account account)
        {
            string uploadedFileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            UploadError uploadError = new UploadError
            {
                DateUploaded = DateTime.UtcNow,
                ErrorDetails = "",
                UploadedBy = account.Id,
                UploadedByName = $"{account.FirstName} {account.LastName}",
                FileName = uploadedFileName,
            };



            if (formFile == null || formFile.Length <= 0)
            {

                uploadError.ErrorDetails = "Uploaded file was Empty";
                await saveUploadedError(uploadError);
                throw new AppException("File cannot be null or empty");
            }

            List<string> fileHeaders = new List<string>();
            FileUpload fileUpload = new FileUpload();

            string fileExtension = Path.GetExtension(formFile.FileName);
            int fileId = 0;

            if (fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                //Todo upload large file to path and seed the file content to database

                //check if file has already been uploaded 
                var existingFIle = _context.FileUploads.FirstOrDefault(x => x.FileName == formFile.FileName);
                if (existingFIle != null)
                {
                    uploadError.ErrorDetails = "FIle has already been uploaded";
                    await saveUploadedError(uploadError);
                    throw new AppException("This file has already been uploaded");
                }


                var folderName = Path.Combine("AppUploads", "UserData");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var filePath = Path.Combine(folderName, fileName);


                filePath = filePath.Replace("\\", "//");

                if (File.Exists(fullPath))
                {
                    try
                    {
                        File.Delete(fullPath);
                    }
                    catch (Exception)
                    {


                    }

                }

                using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    formFile.CopyTo(stream);
                    stream.Dispose();
                }


                try
                {
                    List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();
                    fileUpload = new FileUpload
                    {
                        UploadedBy = account.Id,
                        DateUploaded = DateTime.UtcNow,
                        FileName = formFile.FileName,
                        FileType = fileExtension,
                        DownloadUrl = filePath,
                        HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                        IsInPreviewMode = true,
                        FileSize = StringHelpers.FileSize(fullPath),

                    };

                    _context.FileUploads.Add(fileUpload);
                    _context.SaveChanges();
                    fileId = fileUpload.Id;

                    if (fileExtension.ToLower() == ".csv")
                    {
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HeaderValidated = null,
                            MissingFieldFound = null,
                            PrepareHeaderForMatch = args => args.Header.ToLower().Replace(" ",""),
                           

                        };
                        //Todo read file from excel and bulk insert into db
                        using (var reader2 = new StreamReader(fullPath))
                        using (var csv = new CsvReader(reader2, config))
                        {

                            userDataToSave = csv.GetRecords<UserImportlDataDto>().ToList();

                            //validate that the headers from the upload are part of the defined columns in the database

                            var headers = csv.HeaderRecord;
                            foreach (var item in headers)
                            {
                                var updatedItem = item.Replace(" ", "");
                                fileHeaders.Add(updatedItem.ToLower());
                                if (!Constants.Columns.Contains(updatedItem.ToLower()))
                                {
                                    _context.FileUploads.Remove(fileUpload);
                                    _context.SaveChanges();
                                    try
                                    {
                                        File.Delete(fullPath);
                                    }
                                    catch (Exception) { }

                                    uploadError.ErrorDetails = $"{item} is not a valid header,\nHeader must be part of" +
                                        $" {JsonConvert.SerializeObject(Constants.Columns)}";
                                    await saveUploadedError(uploadError);

                                    throw new AppException($"{item} is not a valid header,\nHeader must be part of" +
                                        $" {JsonConvert.SerializeObject(Constants.Columns)}");
                                }
                            }

                        }
                    }
                    else if (fileExtension.ToLower() == ".xlsx")
                    {
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HeaderValidated = null,
                            MissingFieldFound = null,
                            PrepareHeaderForMatch = args => args.Header.ToLower().Replace(" ", ""),

                        };

                        //Todo read file from excel and bulk insert into db
                        var parser = new ExcelParser(fullPath, "sheet1", config);



                        using var reader = new CsvReader(parser);
                        userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();
                        var headers = reader.HeaderRecord;
                       

                        foreach (var item in headers)
                        {
                            var updatedItem = item.Replace(" ", "");
                            fileHeaders.Add(updatedItem.ToLower());
                            if (!Constants.Columns.Contains(updatedItem.ToLower()))
                            {
                                _context.FileUploads.Remove(fileUpload);
                                _context.SaveChanges();
                                try
                                {
                                    File.Delete(fullPath);
                                }
                                catch (Exception)
                                {
                                }

                                uploadError.ErrorDetails = $"{item} is not a valid header,\nHeader must be part of" +
                                  $" {JsonConvert.SerializeObject(Constants.Columns)}";
                                await saveUploadedError(uploadError);

                                throw new AppException($"{item} is not a valid header,\nHeader must be part of" +
                                    $" {JsonConvert.SerializeObject(Constants.Columns)}");
                            }
                        }
                    
                    }




                    List<UserData> userDatas = new List<UserData>();
                    foreach (var item in userDataToSave)
                    {

                        userDatas.Add(new UserData
                        {
                            Created = DateTime.UtcNow,
                            CreatedBy = account.Id,
                            Email = item.Email,
                            FileId = fileUpload.Id,
                            FirstName = item.FirstName,
                            Gender = item.Gender,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            State = item.State,
                            FileFields = JsonConvert.SerializeObject(fileHeaders),
                            Age = item.Age,
                            Address = item.Address,
                            AgeCohorts = item.AgeCohorts,
                            AirtimeUsage = item.AirtimeUsage,
                            DateOfBirth = item.DateOfBirth,
                            IncomeClass=item.IncomeClass,
                            LGA = item.LGA,
                            MobileNumber = item.MobileNumber,
                            MobilePhone = item.MobilePhone,
                            MobilephoneType = item.MobilephoneType,
                            Occupation = item.Occupation,
                            PollingUnit = item.PollingUnit,
                            PVC = item.PVC,
                            RAC = item.RAC,
                            StateofOrigin = item.StateofOrigin,
                            StateOfResidence = item.StateOfResidence,
                            TelcoProvider= item.TelcoProvider,
                            VotingLGA = item.VotingLGA,
                            VotingRAC = item.VotingRAC,
                            WorkStatus = item.WorkStatus,
                        });
                    }
                    var fileSize = StringHelpers.FileSize(fullPath);
                    fileUpload.FileSize = fileSize;
                    fileUpload.Fields = JsonConvert.SerializeObject(fileHeaders);
                    fileUpload.TotalRecordCount = userDatas.Count;
                    _context.FileUploads.Update(fileUpload);

                    _context.SaveChanges();
                    await _context.BulkInsertAsync(userDatas);

                    return new Response<int>
                    {
                        Data = fileId,
                        Message = "File Upload sucessfull",
                        Succeeded = true,

                    };

                }
                catch (Exception ex)
                {

                    try
                    {
                        File.Delete(fullPath);
                        _context.FileUploads.Remove(fileUpload);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                    }


                    return new Response<int>
                    {
                        Data = 0,
                        Message = "File Upload Failed",
                        Succeeded = false,

                    };
                }



            }

            uploadError.ErrorDetails = "FIle format not supported\nOnly .xlsx and .csv format is supported";
            await saveUploadedError(uploadError);

            throw new AppException("Only .xlsx and .csv format is supported");

        }

        public PagedResponse<List<FileUploadDto>> GetUserPreviewedFiles(PaginationFilter filter, Account Account, string route)
        {
            var pagedData = new List<FileUpload>();
            int totalRecords = 0;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();

                totalRecords = _context.FileUploads.Count(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true);
            }
            else
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true && x.UploadedBy == Account.Id)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();

                totalRecords = _context.FileUploads.Count(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true && x.UploadedBy == Account.Id);
            }


            var filesUploadToReturn = _mapper.Map<List<FileUploadDto>>(pagedData);
            filesUploadToReturn = GenericHelper.SortData(filesUploadToReturn, filter.sortBy, filter.sortOrder);

            var pagedReponse = PaginationHelper.CreatePagedReponse<FileUploadDto>(filesUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public Response<string> SavePreviewedFile(int FileId)
        {
            var existingUploads = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            if (existingUploads == null)
                throw new AppException("File Id not valid");
            existingUploads.IsInPreviewMode = false;
            existingUploads.DateSaved = DateTime.UtcNow;
            _context.FileUploads.Update(existingUploads);
            _context.SaveChanges();

            return new Response<string>
            {
                Data = "",
                Message = "File saved Sucessful",
                Succeeded = true
            };
        }


        public PagedResponse<List<UserDataDto>> ViewFileContents(int FileId, PaginationFilter filter, string route)
        {
            List<int> mergedids = new List<int>();
            List<UserData> pagedData = new List<UserData>();
            var userData = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            int count = 0;
            if (userData == null)
                throw new AppException("Inavlid file Id");

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            pagedData = _context.UserDatas.Where(x => x.FileId == FileId)
       .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
       .Take(validFilter.PageSize)
       .ToList();
            count = _context.UserDatas.Where(x => x.FileId == FileId).Count();
            //    }

            var totalRecords = count;
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);
            userDataToReturn = GenericHelper.SortData(userDataToReturn, filter.sortBy, filter.sortOrder);

            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDataDto>(userDataToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;



        }

        public Response<string> DeleteFile(int FileId)
        {
            //get file and delte all file and it contents
            var existingFile = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            if (existingFile == null)
                throw new AppException("Inavlid file Id");


            var allFileContents = _context.UserDatas.Where(x => x.FileId == FileId);

            _context.FileUploads.Remove(existingFile);

            _context.RemoveRange(allFileContents.ToList());
            _context.SaveChanges();

            //     
            return new Response<string>
            {
                Data = "",
                Message = "Delete Sucessful",
                Succeeded = true
            };
        }

        public async Task<Response<string>> UpdateFile(UpdateFile updateFile, Account account)
        {
            string fullPath = "";
            FileUpload existingFile = _context.FileUploads.FirstOrDefault(x => x.Id == updateFile.FileId);
            if (existingFile == null)
                throw new AppException("Inavlid file Id");

            List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();
            string headerFields  = "";
            string[] headers = { };
            string fileExtension = Path.GetExtension(updateFile.FileContents.FileName);

            if (fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
              fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {

                if (updateFile.FileContents != null && updateFile.FileContents.Length > 0)
                {
                    var folderName = Path.Combine("AppUploads", "UpdatedeUserData");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    var fileName =Guid.NewGuid().ToString() + updateFile.FileContents.FileName;
                     fullPath = Path.Combine(pathToSave, fileName);
                    var filePath = Path.Combine(folderName, fileName);
                    filePath = filePath.Replace("\\", "//");
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        updateFile.FileContents.CopyTo(stream);
                    }

                    if (fileExtension.ToLower() == ".xlsx")
                    {
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HeaderValidated = null,
                            MissingFieldFound = null,
                    };
                        var parser = new ExcelParser(fullPath, "sheet1", config);
                        using var reader = new CsvReader(parser);
                        userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();
                        var fileForUpdatesFilelds = JsonConvert.DeserializeObject<List<string>>(existingFile.Fields);
                         headers = reader.HeaderRecord;
                        headerFields = JsonConvert.SerializeObject(headers);
                      await validateHeaders(headers, fileForUpdatesFilelds,fileName,fullPath,account,existingFile.Fields);

                     
                     }


                    if (fileExtension.ToLower() == ".csv")
                    {
                        //Todo read file from excel and bulk insert into db
                        using (var reader2 = new StreamReader(fullPath))
                        using (var csv = new CsvReader(reader2, CultureInfo.InvariantCulture))
                        {
                            userDataToSave = csv.GetRecords<UserImportlDataDto>().ToList();
                             headers = csv.HeaderRecord;
                            headerFields = JsonConvert.SerializeObject(headers);
                            var fileForUpdatesFilelds = JsonConvert.DeserializeObject<List<string>>(existingFile.Fields);
                            await validateHeaders(headers, fileForUpdatesFilelds, fileName, fullPath, account, existingFile.Fields);
                        }

                    }


                    //Todo update for file

                    List<UserData> userDatas = new List<UserData>();
                    foreach (var item in userDataToSave)
                    {
                        userDatas.Add(new UserData
                        {
                            Created = DateTime.UtcNow,
                            CreatedBy = account.Id,
                            Email = item.Email,
                            FileId = updateFile.FileId,
                            FirstName = item.FirstName,
                            Gender = item.Gender,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            State = item.State,
                            Age = item.Age,
                            AgeCohorts = item.AgeCohorts,
                            AirtimeUsage = item.AirtimeUsage,
                            DateOfBirth = item.DateOfBirth,
                            FileFields = headerFields,
                            IncomeClass = item.IncomeClass,
                            LGA = item.LGA,
                            MobileNumber = item.MobileNumber,
                            MobilePhone = item.MobilePhone,
                            Occupation = item.Occupation,
                            PollingUnit = item.PollingUnit,
                            PVC = item.PVC,
                            StateOfResidence = item.StateOfResidence,
                            TelcoProvider = item.TelcoProvider,
                            VotingLGA = item.VotingLGA,
                            VotingRAC = item.VotingRAC,
                            WorkStatus = item.WorkStatus,

                        }) ;
                    }
                    await _context.BulkInsertAsync(userDatas);
                    _context.SaveChanges();

                    //Delete the file for update
                    try
                    {
                        File.Delete(fullPath); 
                    }
                    catch (Exception ex){}

                    return new Response<string>
                    {
                        Data = "",
                        Message = "File Update sucessfull",
                        Succeeded = true,
                    };

                }

                throw new AppException("File Contents Cannot be empty");
            }

            throw new AppException("Only .csv and .xlsx files are allowed");
        }


        async Task validateHeaders(string[] headers, List<string> fileForUpdatesFilelds, string fileName,string fullPath, Account account,string Fields)
        {
            if (headers.Length != fileForUpdatesFilelds.Count)
            {
                string errorDetails = $"Headers for existing file update do not match -- {Fields}";
                _context.UploadErrors.Add(new UploadError
                {
                    DateUploaded = DateTime.UtcNow,
                    ErrorDetails = errorDetails,
                    FileName = fileName,
                    UploadedBy = account.Id,
                    UploadedByName = $"{account.FirstName} {account.LastName}"
                });
                await _context.SaveChangesAsync();
                throw new AppException(errorDetails);
            }
            for (int i = 0; i < fileForUpdatesFilelds.Count; i++)
            {
                var sourceHeader = headers[i].Replace(" ", "").Trim().ToLower();
                var destheader = fileForUpdatesFilelds[i].Replace(" ", "").Trim().ToLower();
    
                if (sourceHeader != destheader)
                {
                    try
                    {
                        File.Delete(fullPath);
                    }
                    catch (Exception) { }
                    string errorDetails = $"File for upload not properly formatted, it must be in the order {Fields}";
                    _context.UploadErrors.Add(new UploadError
                    {
                        DateUploaded = DateTime.UtcNow,
                        ErrorDetails = errorDetails,
                        FileName = fileName,
                        UploadedBy = account.Id,
                        UploadedByName = $"{account.FirstName} {account.LastName}"
                    });
                    await _context.SaveChangesAsync();
                    throw new AppException($"File for upload not properly formatted, it must be in the order {Fields}");
                }
            }
        }


        //generate merge quety

        //string generateMergeQuery(MergeUserDataDto mergeUserDataDto)
        //{
        //    string selectPart = "select ";

        //    foreach (var item2 in mergeUserDataDto.MergeData)
        //    {
        //        var result = item2.TableName + "." + string.Join($", {item2.TableName}.", item2.TabeleFields);
        //        selectPart += result + ",";

        //    }


        //    selectPart = $"{selectPart.TrimEnd(',')} FROM {mergeUserDataDto.MergeData[0].TableName}";

        //    string InnerJoinPath = "";


        //    for (int i = mergeUserDataDto.MergeData.Count - 1; i >= 0; i--)
        //    {

        //        if (i != 0)
        //        {
        //            for (int j = 0; j < mergeUserDataDto.FieldsForMerging.Count; j++)
        //            {
        //                InnerJoinPath += $"INNER JOIN {mergeUserDataDto.MergeData[i].TableName} ON" +
        //                    $" {mergeUserDataDto.MergeData[i].TableName}.{mergeUserDataDto.FieldsForMerging[j]} = {mergeUserDataDto.MergeData[i - 1].TableName}.{mergeUserDataDto.FieldsForMerging[j]},";
        //            }
        //        }

        //    }
        //    InnerJoinPath = InnerJoinPath.Trim(',');


        //    string orderBy = $"ORDER BY {mergeUserDataDto.MergeData[0].TableName}.{mergeUserDataDto.MergeData[0].TabeleFields[0]} ASC;";

        //    string query = $"{selectPart} {InnerJoinPath} {orderBy}";

        //    return query;

        //}


        public void WriteToExcel(DataTable dt, string path)
        {
            //using (var writer = new StreamWriter(path))
            using (var csv = new ExcelWriter(path, CultureInfo.InvariantCulture))

            {
                // Write columns
                foreach (DataColumn column in dt.Columns)
                {
                    csv.WriteField(column.ColumnName);
                }
                csv.NextRecord();

                // Write row values
                foreach (DataRow row in dt.Rows)
                {
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        csv.WriteField(row[i]);
                    }
                    csv.NextRecord();
                }
            }
        }

        public async Task<Response<int>> ProcessFile(ProcessFileRequest processFileRequest, Account account)
        {
            //generate sql query from inofrmation

            //chck if file for processing exist

            var existingFile = _context.FileUploads.FirstOrDefault(x => x.Id == processFileRequest.FileId);
            if (existingFile == null)
                throw new AppException("File for processing does not exist");

            string rules = JsonConvert.SerializeObject(processFileRequest.processingQueries);

            var sqlQUery = QueryGenerator.GenerateQuery(processFileRequest.processingQueries, existingFile.Id);
            var result = await _dapperDbConnection.QueryAsync<UserImportlDataDto>(sqlQUery);

            if (result.Count == 0)
            // if (0 == 0)
            {
                return new Response<int>
                {
                    Data = 0,
                    Message = "Processing Rule returned no result",
                    Succeeded = false
                };
            }


            var folderName = Path.Combine("AppUploads", "Processed");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = processFileRequest.FileName + ".xlsx";
            var fullPath = Path.Combine(pathToSave, fileName);
            var filePath = Path.Combine(folderName, fileName);
            filePath = filePath.Replace("\\", "//");
            using (var writer = new ExcelWriter(fullPath))
            {
                writer.WriteRecords(result);
            }



            FileUpload fileUpload = new FileUpload
            {
                UploadedBy = account.Id,
                DateUploaded = DateTime.UtcNow,
                FileName = processFileRequest.FileName,
                FileType = ".xlsx",
                DownloadUrl = filePath,
                HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                IsInPreviewMode = false,
                DateSaved = DateTime.UtcNow,
                FileSize = StringHelpers.FileSize(fullPath),
                IsProcessed = true,
                DateProcessed = DateTime.UtcNow,
                TotalRecordCount = result.Count,
                HourProcessed = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                ProcessedBy = account.Id,
                Fields = existingFile.Fields,
            };
            _context.FileUploads.Add(fileUpload);
            _context.SaveChanges();


            //save user data in the database


            ProcessedFileDetails processedFileDetails = new ProcessedFileDetails
            {
                Administrator = account.Id,
                DateProcessed = DateTime.UtcNow,
                FileId = fileUpload.Id,
                FileName = fileUpload.FileName,
                ProcessRule = rules,
                AdministratorName = $"{account.FirstName} {account.LastName}",
                DownloadUrl = filePath,
                Fields = existingFile.Fields,
                Title = processFileRequest.Title,
                UploadedFileCount = existingFile.TotalRecordCount,
                ProcessedItemCount = result.Count,
                HourProcessed = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
            };

            _context.ProcessedFileDetails.Add(processedFileDetails);



            //save file record in the database
            List<UserData> userDatas = new List<UserData>();
            foreach (var item in result)
            {

                userDatas.Add(new UserData
                {
                    Created = DateTime.UtcNow,
                    CreatedBy = account.Id,
                    Email = item.Email,
                    FileId = fileUpload.Id,
                    FirstName = item.FirstName,
                    Gender = item.Gender,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    State = item.State,
                    FileFields = existingFile.Fields,
                    Age = item.Age,
                });
            }


            _context.SaveChanges();
            await _context.BulkInsertAsync(userDatas);



            return new Response<int>
            {
                Data = processedFileDetails.Id,
                Message = "Processing Sucessful",
                Succeeded = true
            };


        }



        public PagedResponse<List<UserProcessedFileDetailsDto>> GetProcessedFiles(PaginationFilter filter, string route, Account Account)
        {
            var pagedData = new List<ProcessedFileDetails>();
            int totalRecords = 0;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.ProcessedFileDetails.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.ProcessedFileDetails.Count();
            }
            else
            {
                pagedData = _context.ProcessedFileDetails.Where(x => x.Administrator == Account.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.ProcessedFileDetails.Where(x => x.Administrator == Account.Id).Count();
            }


            var processedUploadToReturn = _mapper.Map<List<UserProcessedFileDetailsDto>>(pagedData);
            processedUploadToReturn = GenericHelper.SortData(processedUploadToReturn, filter.sortBy, filter.sortOrder);
            var pagedReponse = PaginationHelper.CreatePagedReponse<UserProcessedFileDetailsDto>(processedUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }


        public PagedResponse<List<UserDataDto>> ViewProcessedFileContents(int FileId, PaginationFilter filter, string route)
        {
            List<int> mergedids = new List<int>();
            List<UserData> pagedData = new List<UserData>();
            var processedData = _context.ProcessedFileDetails.FirstOrDefault(x => x.FileId == FileId);
            int count = 0;
            if (processedData == null)
                throw new AppException("Processed file does not exist");

            //get file that holds all the data and read the data into a list



            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            pagedData = _context.UserDatas.Where(x => x.FileId == processedData.FileId)
       .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
       .Take(validFilter.PageSize)
       .ToList();
            count = _context.UserDatas.Where(x => x.FileId == processedData.FileId).Count();


            var totalRecords = count;
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);
            userDataToReturn = GenericHelper.SortData(userDataToReturn, filter.sortBy, filter.sortOrder);

            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDataDto>(userDataToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;



        }

        public Response<ProcessedFileDetailsDto> GetProcessedFileById(int Id)
        {
            var processedFile = _context.ProcessedFileDetails.FirstOrDefault(x => x.Id == Id);
            if (processedFile == null)
                throw new KeyNotFoundException("Processed file does not exist");

            var dataToReturn = _mapper.Map<ProcessedFileDetailsDto>(processedFile);

            return new Response<ProcessedFileDetailsDto>
            {
                Data = dataToReturn,
                Message = "Sucessful",
                Succeeded = true
            };
        }


        public PagedResponse<List<UploadError>> GetUploadedErrors(PaginationFilter filter, string route, Account Account)
        {
            var pagedData = new List<UploadError>();
            int totalRecords = 0;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.UploadErrors.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.UploadErrors.Count();
            }
            else
            {
                pagedData = _context.UploadErrors.Where(x => x.UploadedBy == Account.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.UploadErrors.Where(x => x.UploadedBy == Account.Id).Count();
            }

            pagedData = GenericHelper.SortData(pagedData, filter.sortBy, filter.sortOrder);
            var pagedReponse = PaginationHelper.CreatePagedReponse<UploadError>(pagedData, validFilter, totalRecords, _uriService, route);
            return pagedReponse;
        }


        public DownloadResponse DownloadFileUsingFields(int FileId)
        {
            DownloadResponse downloadResponse = new DownloadResponse();
            string fileName = "";
            {
                using var memoryStream = new MemoryStream();

                {
                    using var excelWriter = new ExcelWriter(memoryStream, CultureInfo.InvariantCulture);
                    var dataForDownload = _context.UserDatas.Where(x => x.FileId == FileId).ToList();
                    var fields = JsonConvert.DeserializeObject<List<string>>(dataForDownload[0].FileFields);
                    var fileUpload = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
                    fileName = fileUpload.FileName;


                    foreach (var field in fields)
                    {
                        excelWriter.WriteField(field);
                    }
                    excelWriter.NextRecord();

                    foreach (var item in dataForDownload)
                    {

                        foreach (var item2 in fields)
                        {
                            var fieldValue = GenericHelper.GetPropertyValue<UserData>(item2, item) == null ?  "":GenericHelper.GetPropertyValue<UserData>(item2, item);
                            excelWriter.WriteField(@$"'{fieldValue.ToString()}");
                        }
                        excelWriter.NextRecord();
                    }
                    memoryStream.Position = 0;
                }

                downloadResponse.DOwnloadData = memoryStream.ToArray();
                downloadResponse.FileName = fileName;
            }
            return downloadResponse;
        }

        public DownloadResponse DownloadFile(int FileId)
        {
            DownloadResponse downloadResponse = new DownloadResponse();
            string fileName = "";
            {
                using var memoryStream = new MemoryStream();

                {
                    using var excelWriter = new ExcelWriter(memoryStream, CultureInfo.InvariantCulture);
                    var dataForDownload = _context.UserDatas.Where(x => x.FileId == FileId).ToList();
                    var fileUpload = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
                    fileName = fileUpload.FileName;
                    var dataForExport = _mapper.Map<List<UserImportlDataDto>>(dataForDownload);
                    excelWriter.WriteRecords(dataForExport);
                    memoryStream.Position = 0;
                }

                downloadResponse.DOwnloadData = memoryStream.ToArray();
                downloadResponse.FileName =fileName;
            }
            return downloadResponse;
        }



        //
        private async Task saveUploadedError(UploadError uploadError)
        {
            _context.Add(uploadError);
            await _context.SaveChangesAsync();
        }
    }
}
