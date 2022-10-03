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
        Response<string> UploadUserData(IFormFile formFile, int AdminId);
        PagedResponse<List<UserDataDto>> ViewUserUploadData(int FileId, PaginationFilter filter, string route);
        Response<string> MergeUserData(MergeUserDataDto mergeUserDataDto, int AdminId);

        Response<string> PreviewFile(IFormFile formFile, int AdminId);

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

        public Response<string> MergeUserData(MergeUserDataDto mergeUserDataDto, int AdminId)
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
                        throw new AppException("Selected Fields for merging must be present in Files selected for merging");     
                    }
                }
            }



            //generate sql query for merge data

            //write the merge result into a file

            //create a merge upload for the file

            //write the merge result into a table


          //  return sucessful result


            


            List<UserData> userDataMergeList = new List<UserData>();

            var existingFiles = _context.FileUploads.Select(x => x.Id).ToList();
            var fileTypes = new List<string>();
            foreach (var item in mergeUserDataDto.FilesIds)
            {
                if (!existingFiles.Contains(item))
                {
                    throw new Exception("Merging operations contains an invalid file");
                }

                userDataMergeList.AddRange(_context.UserDatas.Where(x => x.FileId == item));

                var file = _context.FileUploads.SingleOrDefault(x => x.Id == item);
                fileTypes.Add(file.FileType);
            }

            var fileTypeCOunt = fileTypes.Distinct().Count();
            if (fileTypeCOunt > 1)
            {
                throw new Exception("File Types must be distinct.");
            }

            //Tdod throw exeception if file type is not distinct

            string fileType = fileTypes[0];
            //write the merge list to a file --either excel or csv
            var folderName = Path.Combine("AppUploads", "UserData");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = mergeUserDataDto.MergedFileName + fileType;
            var fullPath = Path.Combine(pathToSave, fileName);
            var filePath = Path.Combine(folderName, fileName);
            filePath = filePath.Replace("\\", "//");
            using (var writer = new ExcelWriter(fullPath))
            {
                var dataToWrite = _mapper.Map<List<UserImportlDataDto>>(userDataMergeList);
                writer.WriteRecords(dataToWrite);
            }

            //write merge data to the database

            FileUpload fileUpload = new FileUpload
            {
                FileName = fileName,
                UploadedBy = AdminId,
                DateUploaded = DateTime.Now,
                DownloadUrl = filePath,
                FileType = fileType,
                FileUploadType = FileUploadType.UserData,
                IsMerged = true,
                DateMerged = DateTime.Now,
                MergedBy = AdminId,
                MergedIds = JsonConvert.SerializeObject(mergeUserDataDto.FilesIds),

            };
            _context.FileUploads.Add(fileUpload);
            _context.SaveChanges();
            return new Response<string>
            {
                Succeeded = true,
                Data = "",
                Message = "Merge Sucessful"
            };

        }

        public Response<string> UploadUserData(IFormFile formFile, int AdminId)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                throw new AppException("File cannot be null or empty");
            }

            string fileExtension = Path.GetExtension(formFile.FileName);

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

                _context.connection.Open();
                using (var transaction = _context.connection.BeginTransaction())
                {

                    try
                    {
                        //           _context.Database.UseTransaction(transaction as DbTransaction);

                        List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();

                        FileUpload fileUpload = new FileUpload
                        {
                            UploadedBy = AdminId,
                            DateUploaded = DateTime.UtcNow,
                            FileName = formFile.FileName,
                            FileType = fileExtension,
                            DownloadUrl = filePath,
                            HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                        };

                        _context.FileUploads.Add(fileUpload);
                        _context.SaveChanges();

                        if (fileExtension.ToLower() == ".csv")
                        {
                            //Todo read file from excel and bulk insert into db
                            using (var reader2 = new StreamReader(fullPath))
                            using (var csv = new CsvReader(reader2, CultureInfo.InvariantCulture))
                            {
                                userDataToSave = csv.GetRecords<UserImportlDataDto>().ToList();
                            }
                        }
                        else if (fileExtension.ToLower() == ".xlsx")
                        {
                            //Todo read file from excel and bulk insert into db
                            using var reader = new CsvReader(new ExcelParser(fullPath));
                            userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();
                        }




                        DataTable table = new DataTable();
                        table.TableName = "UserDatas";


                        table.Columns.Add("Id", typeof(string));
                        table.Columns.Add("FirstName", typeof(string));
                        table.Columns.Add("LastName", typeof(string));
                        table.Columns.Add("PhoneNumber", typeof(string));
                        table.Columns.Add("State", typeof(string));
                        table.Columns.Add("Gender", typeof(string));
                        table.Columns.Add("Email", typeof(string));
                        table.Columns.Add("Others", typeof(string));
                        table.Columns.Add("FileId", typeof(int));
                        table.Columns.Add("Created", typeof(DateTime));
                        table.Columns.Add("CreatedBy", typeof(int));


                        foreach (var userData in userDataToSave)
                        {
                            var row = table.NewRow();
                            row["Id"] = 0;
                            row[nameof(userData.FirstName)] = userData.FirstName;
                            row[nameof(userData.LastName)] = userData.LastName;
                            row[nameof(userData.PhoneNumber)] = userData.PhoneNumber;
                            row[nameof(userData.State)] = userData.State;
                            row[nameof(userData.Gender)] = userData.Gender;
                            row[nameof(userData.Email)] = userData.Email;
                            row[nameof(userData.Others)] = userData.Others;
                            row["Created"] = DateTime.Now;
                            row["CreatedBy"] = AdminId;
                            row["FileId"] = fileUpload.Id;
                            table.Rows.Add(row);
                        }


                        _context.BulkInsert(table);
                        _context.SaveChanges();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        File.Delete(fullPath);
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        _context.connection.Close();
                    }

                }


                return new Response<string>
                {
                    Data = "",
                    Message = "File Upload sucessfull",
                    Succeeded = true,

                };


            }

            throw new AppException("Only .xlsx and .csv format is supported");

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
                mergedids.AddRange(JsonConvert.DeserializeObject<List<int>>(userData.MergedIds));
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

        public Response<string> PreviewFile(IFormFile formFile, int AdminId)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                throw new AppException("File cannot be null or empty");
            }

            string fileExtension = Path.GetExtension(formFile.FileName);

            if (fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                //Todo upload large file to path and seed the file content to database

                //check if file has already been uploaded 
                var existingFIle = _context.FileUploads.FirstOrDefault(x => x.FileName == formFile.FileName);
                //if (existingFIle != null)
                //    throw new AppException("This file has already been uploaded");

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

                _context.connection.Open();
                using (var transaction = _context.connection.BeginTransaction())
                {

                    try
                    {
                        //           _context.Database.UseTransaction(transaction as DbTransaction);

                        List<UserImportlDataDto> userDataToSave = new List<UserImportlDataDto>();

                        FileUpload fileUpload = new FileUpload
                        {
                            UploadedBy = AdminId,
                            DateUploaded = DateTime.UtcNow,
                            FileName = formFile.FileName,
                            FileType = fileExtension,
                            DownloadUrl = filePath,
                            HourUploaded = StringHelpers.getHourActivated(DateTime.UtcNow.Hour),
                            IsInPreviewMode = true,
                        };

                        _context.FileUploads.Add(fileUpload);
                        _context.SaveChanges();

                        if (fileExtension.ToLower() == ".csv")
                        {
                            //Todo read file from excel and bulk insert into db
                            using (var reader2 = new StreamReader(fullPath))
                            using (var csv = new CsvReader(reader2, CultureInfo.InvariantCulture))
                            {
                                userDataToSave = csv.GetRecords<UserImportlDataDto>().ToList();
                            }
                        }
                        else if (fileExtension.ToLower() == ".xlsx")
                        {
                            //Todo read file from excel and bulk insert into db
                            using var reader = new CsvReader(new ExcelParser(fullPath));
                            userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();
                        }


                        DataTable table = new DataTable();
                        table.TableName = "UserDatas";

                        table.Columns.Add("Id", typeof(int));

                        table.Columns.Add("FirstName", typeof(string));
                        table.Columns.Add("LastName", typeof(string));
                        table.Columns.Add("Email", typeof(string));
                        table.Columns.Add("State", typeof(string));
                        table.Columns.Add("PhoneNumber", typeof(string));
                        table.Columns.Add("FileId", typeof(int));
                        table.Columns.Add("Created", typeof(DateTime));

                        table.Columns.Add("CreatedBy", typeof(int));

                        table.Columns.Add("Gender", typeof(string));

                        table.Columns.Add("Others", typeof(string));

                        //int




                        //dateTime



                        foreach (var userData in userDataToSave)
                        {
                            var row = table.NewRow();

                            row["Id"] = 0;
                            row[nameof(userData.FirstName)] = userData.FirstName;
                            row[nameof(userData.LastName)] = userData.LastName;
                            row[nameof(userData.Email)] = userData.Email;
                            row[nameof(userData.State)] = userData.State;
                            row[nameof(userData.PhoneNumber)] = userData.PhoneNumber;
                            row["FileId"] = fileUpload.Id;
                            row["Created"] = DateTime.Now;
                            row["CreatedBy"] = AdminId;
                            row[nameof(userData.Gender)] = userData.Gender;
                            row[nameof(userData.Others)] = userData.Others;

                            table.Rows.Add(row);
                        }


                        _context.BulkInsert(table);
                        _context.SaveChanges();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        File.Delete(fullPath);
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        _context.connection.Close();
                    }

                }


                return new Response<string>
                {
                    Data = "",
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
                mergedids.AddRange(JsonConvert.DeserializeObject<List<int>>(userData.MergedIds));
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
            _context.UserDatas.RemoveRange(allFileContents);

            _context.SaveChanges();
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

                            else if (fileExtension.ToLower() == ".xlsx")
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

                                userDataToSave = reader.GetRecords<UserImportlDataDto>().ToList();

                                //create a datatable from the file and do a bulk insert
                                DataTable table = new DataTable();
                                table.TableName = "UserDatas";


                                table.Columns.Add("Id", typeof(string));
                                table.Columns.Add("FirstName", typeof(string));
                                table.Columns.Add("LastName", typeof(string));
                                table.Columns.Add("PhoneNumber", typeof(string));
                                table.Columns.Add("State", typeof(string));
                                table.Columns.Add("Gender", typeof(string));
                                table.Columns.Add("Email", typeof(string));
                                table.Columns.Add("Others", typeof(string));
                                table.Columns.Add("FileId", typeof(int));
                                table.Columns.Add("Created", typeof(DateTime));
                                table.Columns.Add("CreatedBy", typeof(int));


                                foreach (var userData in userDataToSave)
                                {
                                    var row = table.NewRow();
                                    row["Id"] = 0;
                                    row[nameof(userData.FirstName)] = userData.FirstName;
                                    row[nameof(userData.LastName)] = userData.LastName;
                                    row[nameof(userData.PhoneNumber)] = userData.PhoneNumber;
                                    row[nameof(userData.State)] = userData.State;
                                    row[nameof(userData.Gender)] = userData.Gender;
                                    row[nameof(userData.Email)] = userData.Email;
                                    row[nameof(userData.Others)] = userData.Others;
                                    row["Created"] = DateTime.Now;
                                    row["CreatedBy"] = AdminId;
                                    row["FileId"] = existingFile.Id;
                                    table.Rows.Add(row);
                                }

                                _context.BulkInsert(table);
                                _context.SaveChanges();

                            }
                        }


                        return new Response<string>
                        {
                            Data = "",
                            Message = "File Upload sucessfull",
                            Succeeded = true,

                        };


                    }



                    throw new AppException("File not valid");




                }
           
               throw new AppException("File COntents Cannot be empty");
            }

            throw new AppException("Only .csv and .xlsx files are allowed");
        }
    }
 }
