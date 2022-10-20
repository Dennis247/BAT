using BAT.api.Models.Dtos.Analyze;
using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Models.Entities;
using BAT.api.Services;
using BAT.api.Utils.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MergeController : BaseController
    {
        private readonly IMergeService _mergeService;

        public MergeController(IMergeService mergeService)
        {
            _mergeService = mergeService;
        }



        [HttpGet("GetMergeRules")]
        public IActionResult GetMergeRules()
        {
            var response = _mergeService.GetAllMergeRules();
            return Ok(response);
        }



        [HttpPost("MergeFiles")]
        public IActionResult MergeFiles(MergeDataDto mergeDataDto)
        {
            var response = _mergeService.MergeUserData(mergeDataDto, Account.Id);
            return Ok(response);
        }


      


    }
}
