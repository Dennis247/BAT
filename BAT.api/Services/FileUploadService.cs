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
using System.Net.Http.Headers;

namespace BAT.api.Services
{
    public interface IFileUploadService
    {
        PagedResponse<List<FileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route, Account account);
        PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route);
        Task<Response<int>> MergeUserData(MergeUserDataDto mergeUserDataDto, int AdminId);

        Response<int> PreviewFile(IFormFile formFile, int AdminId);

        PagedResponse<List<FileUploadDto>> GetUserPreviewedFiles(PaginationFilter filter, Account account, string route);

        Response<string> SavePreviewedFile(int FileId);

        PagedResponse<List<UserDataDto>> ViewFileContents(int FileId, PaginationFilter filter, string route);

        Response<string> DeleteFile(int FileId);

        Response<string> UpdateFile(UpdateFile updateFile, int AdminId);


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

        public PagedResponse<List<FileUploadDto>> GetUserFileUploads(PaginationFilter filter, string route, Account account)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = new List<FileUpload>();
            if (account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();
            }
            else
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData && !x.IsInPreviewMode && x.UploadedBy == account.Id)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();
            }

            var totalRecords = _context.FileUploads.Count();
            var filesUploadToReturn = _mapper.Map<List<FileUploadDto>>(pagedData);


            var pagedReponse = PaginationHelper.CreatePagedReponse<FileUploadDto>(filesUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public async Task<Response<int>> MergeUserData(MergeUserDataDto mergeUserDataDto, int AdminId)
        {

            //validate that the file ids for merging are valid

            foreach (var item in mergeUserDataDto.FieldsForMerging)
            {
                var file = _context.FileUploads.Find(item);
                if (file == null)
                    throw new AppException($"File with Id {item} does not exist");
            }

            //check to confirm that the selected merge fields is present in the columns for merging

            foreach (var item in mergeUserDataDto.FieldsForMerging)
            {
                foreach (var item2 in mergeUserDataDto.MergeData.Select(x=>x.TabeleFields))
                {
                    if (!item.Contains(item))
                    {
                        throw new AppException($"Selected Fields for merging must be present in Files selected for merging");     
                    }
                }
            }

            //generate sql query for merge data
            var sqlQuery = generateMergeQuery(mergeUserDataDto);


            //write the merge result into a file
            var result = await _dapperDbConnection.QueryAsync<dynamic>("sqlQuery");

            string JsonList = JsonConvert.SerializeObject(result.ToList());

            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonList);

            var folderName = Path.Combine("AppUploads", "MergedData");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = mergeUserDataDto.MergedFileName + ".xlsx";
            var fullPath = Path.Combine(pathToSave, fileName);
            var filePath = Path.Combine(folderName, fileName);
            filePath = filePath.Replace("\\", "//");

            //write datatTable to excel
            WriteToExcel(dt, fullPath);

            //store merge file in upload table

            FileUpload fileUpload = new FileUpload
            {
                DateMerged =  DateTime.UtcNow,
                DownloadUrl = filePath,
                FileSize = new FileInfo(fullPath).Length / (1024 * 1024),
                UploadedBy = AdminId,
                MergedDetails = JsonConvert.SerializeObject(mergeUserDataDto.MergeData),
                DateUploaded = DateTime.UtcNow,
                IsInPreviewMode = false,
                FileUploadType = FileUploadType.MergedData,
                IsMerged = true,
                MergedBy = AdminId,
                FileName = mergeUserDataDto.MergedFileName,
                FileType = "xlsx",
                DateSaved = DateTime.UtcNow,
                
            };

            _context.FileUploads.Add(fileUpload);
            _context.SaveChanges();
         

            return new Response<int>
            {
                Succeeded = true,
                Data = fileUpload.Id,
                Message = "Merge Sucessful"
            };

        }

    
        public PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route)
        {
            List<int> mergedids = new List<int>();
            List<UserData> pagedData = new List<UserData>();
            var userData = _context.FileUploads.FirstOrDefault(x => x.Id == FileId);
            int count = 0;
            if (userData == null)
                throw new AppException("Inavlid file Id");

            //get file that holds all the data and read the data into a list

            if (userData.IsMerged)
            {
                //special case
              //  mergedids.AddRange(JsonConvert.DeserializeObject<List<int>>(userData.MergedDetails));
            }

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (userData.IsMerged)
            {
                pagedData = _context.UserDatas.Where(x => mergedids.Contains(x.FileId.Value))
           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
           .Take(validFilter.PageSize)
           .ToList();
                count = _context.UserDatas.Count(x => mergedids.Contains(x.FileId.Value));
            }
            else
            {
                pagedData = _context.UserDatas.Where(x => x.FileId == FileId)
           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
           .Take(validFilter.PageSize)
           .ToList();
                count = _context.UserDatas.Count();
            }

            var totalRecords = count;
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);


            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDataDto>(userDataToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;



        }

        public Response<int> PreviewFile(IFormFile formFile, int AdminId)
        {
            if (formFile == null || formFile.Length <= 0)
            {
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
                    throw new AppException("This file has already been uploaded");

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

                double fileSize = (new FileInfo(fullPath).Length)/ (1000);
                fileSize = Math.Round(fileSize, 2);

                    try
                    {
                        List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();
                         fileUpload = new FileUpload
                        {
                            UploadedBy = AdminId,
                            DateUploaded = DateTime.UtcNow,
                            FileName = formFile.FileName,
                            FileType = fileExtension,
                            DownloadUrl = filePath,
                            HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                            IsInPreviewMode = true,
                            FileSize = fileSize,
                        };

                        _context.FileUploads.Add(fileUpload);
                        _context.SaveChanges();
                        fileId = fileUpload.Id;

                        if (fileExtension.ToLower() == ".csv")
                        {
                            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                            {
                                HeaderValidated = null,
                                MissingFieldFound = null
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
                                    fileHeaders.Add(item.ToLower());
                                    if (Constants.Columns.Contains(item.ToLower()))
                                    {
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
                                MissingFieldFound = null
                            };

                            //Todo read file from excel and bulk insert into db
                            var parser = new ExcelParser(fullPath, "sheet1", config);
                            
                            using var reader = new CsvReader(parser);
                            userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();
                            var headers = reader.HeaderRecord;

                            foreach (var item in headers)
                            {
                                fileHeaders.Add(item.ToLower());
                                if (!Constants.Columns.Contains(item.ToLower()))
                                {
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
                                CreatedBy = AdminId,
                                Email = item.Email,
                                FileId = fileUpload.Id,
                                FirstName = item.FirstName,
                                Gender = item.Gender,
                                LastName = item.LastName,
                                PhoneNumber = item.PhoneNumber,
                                State = item.State,
                                FileFields = JsonConvert.SerializeObject(fileHeaders),
                                Age = item.Age,
                            });
                        }
                        fileUpload.Fields = JsonConvert.SerializeObject(fileHeaders); 
                        _context.BulkInsertAsync(userDatas);
                        _context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        File.Delete(fullPath);
                        if(fileUpload != null)
                        {
                            _context.FileUploads.Remove(fileUpload);
                        }
                     
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        _context.connection.Close();
                    }

                return new Response<int>
                {
                    Data = fileId,
                    Message = "File Upload sucessfull",
                    Succeeded = true,

                };


            }

            throw new AppException("Only .xlsx and .csv format is supported");

        }

        public PagedResponse<List<FileUploadDto>> GetUserPreviewedFiles(PaginationFilter filter, Account Account, string route)
        {
            var pagedData = new List<FileUpload>();
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();
            }
            else
            {
                pagedData = _context.FileUploads.Where(x => x.FileUploadType == FileUploadType.UserData
      && x.IsInPreviewMode == true && x.UploadedBy == Account.Id)
         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
         .Take(validFilter.PageSize)
         .ToList();
            }

            var totalRecords = _context.FileUploads.Count();
            var filesUploadToReturn = _mapper.Map<List<FileUploadDto>>(pagedData);


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

            //get file that holds all the data and read the data into a list

            if (userData.IsMerged)
            {
                mergedids.AddRange(JsonConvert.DeserializeObject<List<int>>(userData.MergedDetails));
            }

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (userData.IsMerged)
            {
                pagedData = _context.UserDatas.Where(x => mergedids.Contains(x.FileId.Value))
           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
           .Take(validFilter.PageSize)
           .ToList();
                count = _context.UserDatas.Count(x => mergedids.Contains(x.FileId.Value));
            }
            else
            {
                pagedData = _context.UserDatas.Where(x => x.FileId == FileId)
           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
           .Take(validFilter.PageSize)
           .ToList();
                count = _context.UserDatas.Count();
            }

            var totalRecords = count;
            var userDataToReturn = _mapper.Map<List<UserDataDto>>(pagedData);


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

        public Response<string> UpdateFile(UpdateFile updateFile, int AdminId)
        {
            var existingFile = _context.FileUploads.FirstOrDefault(x => x.Id == updateFile.FileId);
            if (existingFile == null)
                throw new AppException("Inavlid file Id");

            List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();

            string fileExtension = Path.GetExtension(updateFile.FileContents.FileName);

            if (fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
              fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {

                if (updateFile.FileContents != null && updateFile.FileContents.Length > 0)
                {
                    var folderName = Path.Combine("AppUploads", "UpdatedeUserData");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    var fileName = ContentDispositionHeaderValue.Parse(updateFile.FileContents.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var filePath = Path.Combine(folderName, fileName);
                    filePath = filePath.Replace("\\", "//");
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        updateFile.FileContents.CopyTo(stream);
                    }


                    if (fileExtension.ToLower() == ".xlsx")
                    {
                        //Todo read file from excel and bulk insert into db
                        using var reader = new CsvReader(new ExcelParser(fullPath));
                        var headers = reader.HeaderRecord;
                        //check if header of incoming file matches the user Data header
                        if (!(headers[0] == "FirstName" &&
                            headers[1] == "PhoneNumber" &&
                            headers[2] == "State" &&
                            headers[3] == "Gender" &&
                            headers[4] == "Email" &&
                            headers[5] == "Others"))
                        {

                            File.Delete(fullPath);
                            throw new AppException("File for upload not properly formatted");
                        }

                    }


                     if (fileExtension.ToLower() == ".csv")
                    {
                        //Todo read file from excel and bulk insert into db
                        using (var reader2 = new StreamReader(fullPath))
                        using (var csv = new CsvReader(reader2, CultureInfo.InvariantCulture))
                        {
                            var csvHeader = csv.HeaderRecord;
                            userDataToSave = csv.GetRecords<UserImportlDataDto>().ToList();
                            if (!(csvHeader[0] == "FirstName" &&
                           csvHeader[1] == "PhoneNumber" &&
                           csvHeader[2] == "State" &&
                           csvHeader[3] == "Gender" &&
                           csvHeader[4] == "Email" &&
                           csvHeader[5] == "Others"))
                            {
                                throw new Exception("File for update not properly formatted");
                            }
                        }

                    }


                     //Todo update for file
                    List<UserData> userDatas = new List<UserData>();
                    foreach (var item in userDataToSave)
                    {
                        userDatas.Add(new UserData
                        {
                            Created = DateTime.UtcNow,
                            CreatedBy = AdminId,
                            Email = item.Email,
                            FileId = updateFile.FileId,
                            FirstName = item.FirstName,
                            Gender = item.Gender,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            State = item.State,
                            Age = item.Age,
                           
                        });
                    }
                    _context.BulkInsertAsync(userDatas);
                    _context.SaveChanges();

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


        //generate merge quety

        string generateMergeQuery(MergeUserDataDto mergeUserDataDto)
        {
            string selectPart = "select ";

            foreach (var item2 in mergeUserDataDto.MergeData)
            {
                var result = item2.TableName + "." + string.Join($", {item2.TableName}.", item2.TabeleFields);
                selectPart += result + ",";

            }


            selectPart = $"{selectPart.TrimEnd(',')} FROM {mergeUserDataDto.MergeData[0].TableName}";

            string InnerJoinPath = "";


            for (int i = mergeUserDataDto.MergeData.Count - 1; i >= 0; i--)
            {

                if (i != 0)
                {
                    for (int j = 0; j < mergeUserDataDto.FieldsForMerging.Count; j++)
                    {
                        InnerJoinPath += $"INNER JOIN {mergeUserDataDto.MergeData[i].TableName} ON" +
                            $" {mergeUserDataDto.MergeData[i].TableName}.{mergeUserDataDto.FieldsForMerging[j]} = {mergeUserDataDto.MergeData[i - 1].TableName}.{mergeUserDataDto.FieldsForMerging[j]},";
                    }
                }

            }
            InnerJoinPath = InnerJoinPath.Trim(',');


            string orderBy = $"ORDER BY {mergeUserDataDto.MergeData[0].TableName}.{mergeUserDataDto.MergeData[0].TabeleFields[0]} ASC;";

            string query = $"{selectPart} {InnerJoinPath} {orderBy}";

            return query;

        }


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

    }
 }
