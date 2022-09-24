using BAT.api.Models.Dtos.Candidate;
using BAT.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : BaseController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("GetAllCandidates")]
        public IActionResult GetAllCandidates()
        {
            var response = _candidateService.GetAllCandidates();
            return Ok(response);
        }

        [HttpPost("AddCandidate")]
        public IActionResult AddCandidate(CandidateDto candidateDto)
        {
            var response = _candidateService.AddCandidate(candidateDto, Account.Id);
            return Ok(response);
        }
    }
}
