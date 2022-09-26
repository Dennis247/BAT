using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.Candidate;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using BAT.api.Utils.Filters;
using BAT.api.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace BAT.api.Services
{
    public interface ICandidateService
    {
        Response<int> AddCandidate(AddCandidateDto candidateDto, int AdminId);
        PagedResponse<List<CandidateDto>> GetAllCandidates([FromQuery] PaginationFilter filter, string route);

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
            var existingCandidate = _context.Candidates.FirstOrDefault(
                x => x.FirstName.ToLower().Trim() == candidateDto.FirstName.ToLower().Trim()
            && x.LastName.ToLower().Trim() == candidateDto.LastName.Trim().ToLower() 
            &&  x.Position.ToLower().Trim() == candidateDto.Position.ToLower().Trim()
            && x.AreaRepresenting.ToLower().Trim() == candidateDto.AreaRepresenting.ToLower().Trim());

            if(existingCandidate != null)
            {
                throw new AppException("Candidate Profile already exist");
            }



            //upload image first 
            string imagePath = "";
            if (candidateDto.CandidateImageUpload.Length > 0)
            {
                var folderName = Path.Combine("AppUploads", "CandidatesImage");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = $"{candidateDto.FirstName}_{candidateDto.LastName}.png";
                var fullPath = Path.Combine(pathToSave, fileName);
                 imagePath = Path.Combine(folderName, fileName);
                imagePath = imagePath.Replace("\\", "//");
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    candidateDto.CandidateImageUpload.CopyTo(stream);
                }
              
            }

            var candidateToAdd = _mapper.Map<Candidate>(candidateDto);
            candidateToAdd.CandidateImage = imagePath;


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

        public PagedResponse<List<CandidateDto>> GetAllCandidates([FromQuery] PaginationFilter filter, string route)
        {


            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = _context.Candidates
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();
            var totalRecords = _context.Candidates.Count();
            var candidateToReturn = _mapper.Map<List<CandidateDto>>(pagedData);


            var pagedReponse = PaginationHelper.CreatePagedReponse<CandidateDto>(candidateToReturn, validFilter, totalRecords, _uriService, route);
            return pagedReponse;
         
        }
    }
}
