using BAT.api.Authorization;
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


        [AllowAnonymous]
        [HttpGet("GetAllCandidates")]
        public IActionResult GetAllCandidates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _candidateService.GetAllCandidates(filter,route);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("AddCandidate")]
        public IActionResult AddCandidate([FromForm]AddCandidateDto candidateDto)
        {
            var response = _candidateService.AddCandidate(candidateDto,1);
            return Ok(response);
        }


    }
}
