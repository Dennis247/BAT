using BAT.api.Models.Dtos.Candidate;
using BAT.api.Services;
using BAT.api.Utils.Filters;
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

        [HttpGet("GetAllCandidates")]
        public IActionResult GetAllCandidates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _candidateService.GetAllCandidates(filter,route);
            return Ok(response);
        }

        [HttpPost("AddCandidate")]
        public IActionResult AddCandidate(AddCandidateDto candidateDto)
        {
            var response = _candidateService.AddCandidate(candidateDto, Account.Id);
            return Ok(response);
        }
    }
}
