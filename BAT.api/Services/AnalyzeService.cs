

using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.Analyze;
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
    public interface IAnalyzeService
    {

        PagedResponse<List<AnalyzeDataDto>> GetAnalyzedData(PaginationFilter filter, string route, Account Account);

        Response<AnalyzeResponseResult> AnalyzeData(AnalyzeRequest analyzeRequest, Account account);
        Response<int> RequestForExport(int Id, Account account);
        Response<int> ApproveExport(int Id, Account account);
        Response<int> RejectExport(int Id, Account account);

        Response<ExportAnalyzedData> ExportAnalyzedData(int Id, Account account);

        PagedResponse<List<ExportRequest>> GetExportRequest(int Id, PaginationFilter filter, string route, Account Account);

        Response<AnalyzeData> GetAnalysisById(int Id);
    }

    public class AnalyzeService : IAnalyzeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IUriService _uriService;
        private readonly IDapperDbConnection _dapperDbConnection;

        public AnalyzeService(
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

        public Response<AnalyzeResponseResult> AnalyzeData(AnalyzeRequest analyzeRequest, Account account)
        {
            List<AnalyzeResponse> analyzeResponse = new List<AnalyzeResponse>();
            AnalyzeResponseResult analyzeResponseResult = new AnalyzeResponseResult();
            dynamic processedData = null;

            var processedFileDetails = _context.ProcessedFileDetails.FirstOrDefault(x => x.FileId == analyzeRequest.FileId);
            if (processedFileDetails == null)
                throw new AppException("Processed File Details not found for this file");

            foreach (var item in analyzeRequest.AnalyzeDtos)
            {
           
                if(item.Field.ToLower() == Constants.Columns[0])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.FirstName into g
                                    select new { key = g.Key, Value = g.ToList().Count() };
                }

              else  if (item.Field.ToLower() == Constants.Columns[1])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.LastName into g
                                    select new { key = g.Key, Value = g.ToList().Count() };
                }

                else if (item.Field.ToLower() == Constants.Columns[2])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.PhoneNumber into g
                                    select new { key = g.Key, Value = g.ToList().Count() };
                }

                else if (item.Field.ToLower() == Constants.Columns[3])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.State into g
                                    select new { key = g.Key, Value = g.ToList().Count() };
                }

                else if (item.Field.ToLower() == Constants.Columns[4])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.Gender into g
                                    select new { key = g.Key, Value = g.ToList().Count() };

                }
                else if (item.Field.ToLower() == Constants.Columns[5])
                {
                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.Email into g
                                    select new { key = g.Key, Value = g.ToList().Count() };

                }

                else if (item.Field.ToLower() == Constants.Columns[6])
                {

                    processedData = from p in _context.UserDatas.Where(x => x.FileId == analyzeRequest.FileId)
                                    group p by p.Age into g
                                    select new { key = g.Key, Value = g.ToList().Count() };
                }






             


                List<Models.Dtos.Analyze.Data> graph = new List<Models.Dtos.Analyze.Data>();

                foreach (var grph in processedData)
                {
                    graph.Add(new Models.Dtos.Analyze.Data { Key = grph.key, Value = grph.Value });
                }




                analyzeResponse.Add(new AnalyzeResponse
                {
                    data = graph,
                    Field = item.Field,
                    ProcessedFileCount = processedFileDetails.ProcessedItemCount,
                    Type = item.Type,
                    WidgetType = item.WidgetType,
                    UploadedFileCount = processedFileDetails.UploadedFileCount,
                    Extras = item.Extras
                });
            }


            var analyzeDataToSave = new AnalyzeData
            {
                AdminId = account.Id,
                AdminName = $"{account.FirstName} {account.LastName}",
                AnalyzedRecord = JsonConvert.SerializeObject(analyzeResponseResult),
                DateCreated = DateTime.UtcNow,
                IsApprovedByAdmin = false,
                Objective = analyzeRequest.Objective,
                FIleId = analyzeRequest.FileId,
            };



            _context.AnalyzeDatas.Add(analyzeDataToSave);
            _context.SaveChanges();

            analyzeResponseResult = new AnalyzeResponseResult
            {
                AnalyzeId = analyzeDataToSave.Id,
                AnalyzeResponses = analyzeResponse,
                Date = DateTime.UtcNow,
                AnalyzedByName = $"{account.FirstName} {account.LastName}",
                AnalyzedBy = account.Id,
                Objective = analyzeRequest.Objective,
                
            };


            analyzeDataToSave.AnalyzedRecord = JsonConvert.SerializeObject(analyzeResponseResult);
            _context.Update(analyzeDataToSave);
            _context.SaveChanges();

            return new Response<AnalyzeResponseResult>
            {
                Data = analyzeResponseResult,
                Message = "sucessful",
                Succeeded = true
            };
        }


        public PagedResponse<List<AnalyzeDataDto>> GetAnalyzedData( PaginationFilter filter, string route, Account Account)
        {
            var pagedData = new List<AnalyzeData>();
            int totalRecords = 0;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.AnalyzeDatas.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.ProcessedFileDetails.Count();
            }
            else
            {
                pagedData = _context.AnalyzeDatas.Where(x => x.AdminId == Account.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.AnalyzeDatas.Where(x => x.AdminId == Account.Id).Count();
            }


            var processedUploadToReturn = _mapper.Map<List<AnalyzeDataDto>>(pagedData);

            processedUploadToReturn = GenericHelper.SortData(processedUploadToReturn, filter.sortBy,filter.sortOrder);

            if (!string.IsNullOrEmpty(filter.filterBy))
            {
                var search = filter.filterBy.ToLower();
                processedUploadToReturn = processedUploadToReturn.Where(x => x.Objective.ToLower().Contains(search)||
                x.AdminName.ToLower().Contains(search)).ToList();
            }


            var pagedReponse = PaginationHelper.CreatePagedReponse<AnalyzeDataDto>(processedUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public Response<int> RejectExport(int Id, Account account)
        {
            var exportRequest = _context.ExportRequests.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if (exportRequest == null)
                throw new AppException("Export Request does not exist");
          
            exportRequest.ExportStatus = Constants.REJECTED;
            exportRequest.RejectedBy = account.Id;
            exportRequest.RejectedByName = $"{account.FirstName} {account.LastName}";
            exportRequest.DateRejected = DateTime.UtcNow;
           
            _context.Update(exportRequest);
            _context.SaveChanges();

            return new Response<int>
            {
                Data = exportRequest.Id,
                Message = "Request Rejected",
                Succeeded = true
            };
        }

        public Response<int> ApproveExport(int Id, Account account)
        {
            var exportRequest = _context.ExportRequests.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if (exportRequest == null)
                throw new AppException("Export REquest does not exist");

            exportRequest.ExportStatus = Constants.APPROVED;
            exportRequest.ApprovedBy = account.Id;
            exportRequest.ApprovedByName = $"{account.FirstName} {account.LastName}";
            exportRequest.DateApproved = DateTime.UtcNow;

            _context.Update(exportRequest);
            _context.SaveChanges();

            return new Response<int>
            {
                Data = exportRequest.Id,
                Message = "Request Approved",
                Succeeded = true
            };
        }

        public Response<int> RequestForExport(int AnalyzedFileId, Account account)
        {
            var  existingAnalyzedFile = _context.AnalyzeDatas.FirstOrDefault(x=>x.Id == AnalyzedFileId);
            if (existingAnalyzedFile == null)
                throw new AppException("Analyzed data for this request does not exist");

            ExportRequest exportRequest = new ExportRequest
            {
                AnalyzeRequestId = existingAnalyzedFile.Id,
                DateRequested = DateTime.UtcNow,
                Objective = existingAnalyzedFile.Objective,
                RequestedBy = account.Id,
                RequestedByName = $"{account.FirstName} {account.LastName}",
                ExportStatus = Constants.PENDING,
                
            };


            _context.Update(exportRequest);
            _context.SaveChanges();

            return new Response<int>
            {
                Data = exportRequest.Id,
                Message = "Request Submitted sucessful",
                Succeeded = true
            };
        }

        public PagedResponse<List<ExportRequest>> GetExportRequest(int Id, PaginationFilter filter, string route, Account Account)
        {
            var pagedData = new List<ExportRequest>();
            int totalRecords = 0;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (Account.Role == ROLES.SuperAdmin)
            {
                pagedData = _context.ExportRequests.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.ExportRequests.Count();
            }
            else
            {
                pagedData = _context.ExportRequests.Where(x => x.RequestedBy == Account.Id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                totalRecords = _context.ExportRequests.Where(x => x.RequestedBy == Account.Id).Count();
            }


            var processedUploadToReturn = _mapper.Map<List<ExportRequest>>(pagedData);
            processedUploadToReturn = GenericHelper.SortData(processedUploadToReturn, filter.sortBy, filter.sortOrder);
            var pagedReponse = PaginationHelper.CreatePagedReponse<ExportRequest>(processedUploadToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public Response<ExportAnalyzedData> ExportAnalyzedData(int Id, Account account)
        {

            ExportAnalyzedData exportAnalyzedData = new ExportAnalyzedData();
            //check if analyzed data exist
            var analyzedData = _context.AnalyzeDatas.FirstOrDefault(x => x.Id == Id);
            if (analyzedData == null)
                throw new AppException("Amalyzed Data does not exist");

            var file = _context.FileUploads.FirstOrDefault(x => x.Id == analyzedData.FIleId);

 

            if(account.Role == ROLES.SuperAdmin)
            {
                exportAnalyzedData = new ExportAnalyzedData
                {
                    DownloadUrl = _appSettings.BaseUrl + file.DownloadUrl,
                    analyzedData = JsonConvert.DeserializeObject<AnalyzeResponseResult>(analyzedData.AnalyzedRecord)
                };

                return new Response<ExportAnalyzedData>
                {
                    Data = exportAnalyzedData,
                    Message = "Export Sucessful",
                    Succeeded = true
                };
            }

            //get export request for analyzed data
            var exportRequest = _context.ExportRequests.FirstOrDefault(x => x.AnalyzeRequestId == Id);
            if (exportRequest == null)
                throw new AppException("Export request for analyzed Data does not exist");

            if (exportRequest.ExportStatus == Constants.APPROVED && exportRequest.RequestedBy == account.Id)
            {
                exportAnalyzedData = new ExportAnalyzedData
                {
                    DownloadUrl =   _appSettings.BaseUrl + file.DownloadUrl,
                    analyzedData =  JsonConvert.DeserializeObject<AnalyzeResponseResult>(analyzedData.AnalyzedRecord)
                };

                return new Response<ExportAnalyzedData>
                {
                    Data = exportAnalyzedData,
                    Message = "Export Sucessful",
                    Succeeded = true
                };
            }

            throw new UnAuthorizedException("You do not have permission to export this Data");
        }


        public Response<AnalyzeData> GetAnalysisById(int Id)
        {
            var data = _context.AnalyzeDatas.FirstOrDefault(x => x.Id == Id);
            if (data == null)
                throw new KeyNotFoundException("Data does not exist");

            return new Response<AnalyzeData>
            {
                Data = data,
                Message = "Sucessful",
                Succeeded = true
            };
        }

        private List<AnalyzeDataDto> SortData(List<AnalyzeDataDto> data, string sortField, string sortOrder)
        {
            try
            {
                string SortField = sortField;
                string SortOrder = sortOrder;


                if (string.IsNullOrEmpty(sortField))
                {
                    SortField = "Id";
                    SortOrder = "asc";
                }

                if (string.IsNullOrEmpty(sortOrder))
                {
                    SortOrder = "asc";
                }

                SortField = StringHelpers.ToTitleCase(SortField);


                var propertyInfo = typeof(AnalyzeDataDto).GetProperty(SortField);
                if (SortOrder == "asc")
                {
                    data = data.OrderBy(s => propertyInfo.GetValue(s, null)).ToList();
                }
                else
                {
                    data = data.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();
                }
                return data;
            }
            catch (Exception)
            {

              return data;
            }
       

        
        }



    }




}


