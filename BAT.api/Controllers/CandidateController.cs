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
        public IActionResult GetAllCandidates([FromQuery] PaginationFilter filter, int UserId)
        {
            var route = Request.Path.Value;
            var response = _candidateService.GetAllCandidates(filter, UserId,route);
            return Ok(response);
        }

 
        [HttpPost("AddCandidate")]
        public IActionResult AddCandidate([FromBody]AddCandidateDto candidateDto)
        {
            var response = _candidateService.AddCandidate(candidateDto,Account.Id);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpGet("GetCandidate")]
        public IActionResult GetCandidate(int Id)
        {
            var response = _candidateService.GetCandidate(Id);
            return Ok(response);
        }


        [HttpPost("DeleteCandidate")]
        public IActionResult DeleteCandidate(DeleteCandidateDto deleteCandidateDto)
        {
            //Todo track in audit trail
            var response = _candidateService.DeleteCandidate(deleteCandidateDto.Id);
            return Ok(response);
        }

        [HttpPost("EditCandidate")]
        public IActionResult EditCandidate(UpdateCandidateDto candidateDto)
        {
            //Todo track in audit trail
            var response = _candidateService.EditCandidate(candidateDto,Account.Id);
            return Ok(response);
        }


    }
}
