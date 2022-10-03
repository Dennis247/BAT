using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.Candidate;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using BAT.api.Utils.Filters;
using BAT.api.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

namespace BAT.api.Services
{
    public interface ICandidateService
    {
        Response<int> AddCandidate(AddCandidateDto candidateDto, int AdminId);
        Response<string> DeleteCandidate(int Id);

        Response<CandidateDto> GetCandidate(int Id);
        Response<CandidateDto> EditCandidate(UpdateCandidateDto candidateDto, int AdminId);
        PagedResponse<List<CandidateDto>> GetAllCandidates([FromQuery] PaginationFilter filter, int UserId, string route);
    }

    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IUriService _uriService;

        public CandidateService(
            ApplicationDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
            IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _uriService = uriService;
        }
        public Response<int> AddCandidate(AddCandidateDto candidateDto, int AdminId)
        {
            //check if candidate has been added before

            candidateDto.AreaRepresenting = candidateDto.AreaRepresenting == null ? "" : candidateDto.AreaRepresenting;

            var existingCandidate = _context.Candidates.FirstOrDefault(
                x => x.FirstName.ToLower().Trim() == candidateDto.FirstName.ToLower().Trim()
            && x.LastName.ToLower().Trim() == candidateDto.LastName.Trim().ToLower()
            && x.Position.ToLower().Trim() == candidateDto.Position.ToLower().Trim()
            && x.AreaRepresenting.ToLower().Trim() == candidateDto.AreaRepresenting.ToLower().Trim());

            if (existingCandidate != null)
            {
                throw new AppException("Candidate Profile already exist");
            }



            //upload image first 
            string imagePath = "";
            if (candidateDto.CandidateImage != null)
            {
                var folderName = Path.Combine("AppUploads", "CandidatesImage");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = $"{candidateDto.FirstName}_{candidateDto.LastName}.png";
                var fullPath = Path.Combine(pathToSave, fileName);
                imagePath = Path.Combine(folderName, fileName);
                imagePath = imagePath.Replace("\\", "//");

                try
                {
                    var bytes = Convert.FromBase64String(candidateDto.CandidateImage);
                    File.WriteAllBytes(fullPath, bytes);
                }
                catch (Exception)
                {

                  
                }
      
            }

            var candidateToAdd = _mapper.Map<Candidate>(candidateDto);
            candidateToAdd.CandidateImage = imagePath;

            candidateToAdd.WhatAppNumber = candidateToAdd.WhatAppNumber == null ? "" : candidateDto.WhatAppNumber;
            candidateToAdd.Created = DateTime.Now;
            candidateToAdd.CreatedBy = AdminId;
            _context.Candidates.Add(candidateToAdd);
            _context.SaveChanges();

            return new Response<int>
            {
                Data = candidateToAdd.Id,
                Message = "Candidate Added Sucessful",
                Succeeded = true
            };
        }

        public Response<string> DeleteCandidate(int Id)
        {
            var existingCandidate = _context.Candidates.AsNoTracking().FirstOrDefault(c => c.Id == Id);
            if (existingCandidate == null)
                throw new KeyNotFoundException("Candidate does not exist");
            _context.Candidates.Remove(existingCandidate);
            _context.SaveChanges();
            return new Response<string>
            {
                Data = "",
                Message = "Candidate deleted sucessful",
                Succeeded = true
            };
        }

        public Response<CandidateDto> EditCandidate(UpdateCandidateDto candidateDto, int AdminId)
        {
            var existingCandidate = _context.Candidates.Find(candidateDto.Id);
            if (existingCandidate == null)
                throw new KeyNotFoundException("Candidate does not exist");

            var dataToSave = _mapper.Map<Candidate>(candidateDto);
            dataToSave.LastTimeModified = DateTime.Now;
            dataToSave.MoidifiedBy = AdminId;
            dataToSave.Created = existingCandidate.Created;
            dataToSave.CreatedBy = existingCandidate.CreatedBy;


            //upload image first 
            string imagePath = "";
            if (candidateDto.CandidateImage != null && candidateDto.CandidateImage !="")
            {
                var folderName = Path.Combine("AppUploads", "CandidatesImage");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = $"{candidateDto.FirstName}_{candidateDto.LastName}.png";
                var fullPath = Path.Combine(pathToSave, fileName);
                imagePath = Path.Combine(folderName, fileName);
                imagePath = imagePath.Replace("\\", "//");

                try
                {
                    var bytes = Convert.FromBase64String(candidateDto.CandidateImage);
                    File.WriteAllBytes(fullPath, bytes);
                }
                catch (Exception)
                {


                }

            }

            _context.Entry(existingCandidate).CurrentValues.SetValues(dataToSave);
            _context.SaveChanges();

            var caniddateToResturn = _mapper.Map<CandidateDto>(existingCandidate);
            return new Response<CandidateDto>
            {
                Data = caniddateToResturn,
                Message = "Candidate updated sucessful",
                Succeeded = true
            };


        }

        public PagedResponse<List<CandidateDto>> GetAllCandidates([FromQuery] PaginationFilter filter, int UserId, string route)
        {

            List<Candidate> pagedData = new List<Candidate>();

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            if (filter.sortBy == "" || filter.sortBy.ToLower() == "firstname")
            {
                if (filter.sortOrder == "desc")
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).OrderByDescending(x => x.FirstName).ToList();
                }
                else
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).OrderBy(x => x.FirstName).ToList();
                }

             
            }
            else if (filter.sortBy.ToLower() == "lastname")
            {
                if (filter.sortOrder == "desc")
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize)
                        .OrderByDescending(x => x.LastName).ToList();

                }
                else
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).
                        OrderBy(x => x.LastName).ToList();
                }

            }

            else if (filter.sortBy.ToLower() == "state")
            {
                if (filter.sortOrder == "desc")
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                  .Take(validFilter.PageSize).OrderByDescending(x => x.State).ToList();
                }
                else
                {
                    pagedData = _context.Candidates.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                  .Take(validFilter.PageSize).OrderBy(x => x.State).ToList();
                }
            }


            if (filter.filterBy != null && filter.filterBy != "")
            {
                pagedData = pagedData.Where(x => x.FirstName.ToLower().Contains(filter.filterBy)
                || x.FirstName.ToLower().Contains(filter.filterBy)
                || x.LastName.ToLower().Contains(filter.filterBy)
                || x.WhatAppNumber!.ToString().Contains(filter.filterBy)
                || x.State.ToLower().Contains(filter.filterBy)
                || x.Position.ToLower().Contains(filter.filterBy)
                || x.AreaRepresenting.ToLower().Contains(filter.filterBy)
                ).ToList();
            }


           
         

            var totalRecords = _context.Candidates.Count();
            var candidateToReturn = _mapper.Map<List<CandidateDto>>(pagedData);
            if (UserId != 0)
            {
                candidateToReturn = candidateToReturn.Where(x => x.CreatedBy == UserId).ToList();
            }


            var pagedReponse = PaginationHelper.CreatePagedReponse<CandidateDto>(candidateToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

        }

        public Response<CandidateDto> GetCandidate(int Id)
        {
            var existingCandidate = _context.Candidates.FirstOrDefault(c => c.Id == Id);
            if (existingCandidate == null)
                throw new KeyNotFoundException("Candidate does not exist");

            var candidateToReturn = _mapper.Map<CandidateDto>(existingCandidate);

            return new Response<CandidateDto>
            {
                Data = candidateToReturn,
                Message = "Sucessful",
                Succeeded = true
            };
        }
    }
}
