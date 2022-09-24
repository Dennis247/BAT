using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.Candidate;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using BAT.api.Utils.Helpers;
using Microsoft.Extensions.Options;

namespace BAT.api.Services
{
    public interface ICandidateService
    {
        Response<int> AddCandidate(CandidateDto candidateDto, int AdminId);
        Response<List<CandidateDto>> GetAllCandidates();
    }
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public CandidateService(
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
        public Response<int> AddCandidate(CandidateDto candidateDto, int AdminId)
        {
            //check if candidate has been added before
            var existingCandidate = _context.Candidates.FirstOrDefault(x => StringHelpers.IsStringEqual(x.FirstName, candidateDto.FirstName)
            && StringHelpers.IsStringEqual(x.LastName,candidateDto.LastName) && StringHelpers.IsStringEqual(x.Position, candidateDto.Position)
            && StringHelpers.IsStringEqual(x.AreaRepresenting, candidateDto.AreaRepresenting));

            if(existingCandidate != null)
            {
                return new Response<int>
                {
                    Data = 0,
                    Message = "Candidate Profile already exist",
                    Succeeded = true
                };
            }

           var candidateToAdd = _mapper.Map<Candidate>(candidateDto);
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

        public Response<List<CandidateDto>> GetAllCandidates()
        {
            var allCandidates = _context.Candidates.ToList();
            var candidateToReturn = _mapper.Map<List<CandidateDto>>(allCandidates);
            return new Response<List<CandidateDto>>
            {
                Data = candidateToReturn,
                Message = "sucessful",
                Succeeded = true
            };
        }
    }
}
