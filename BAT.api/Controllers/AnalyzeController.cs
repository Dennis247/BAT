using BAT.api.Models.Dtos.Analyze;
using BAT.api.Models.Dtos.FileUpload;
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
    public class AnalyzeController : BaseController
    {
        private readonly IAnalyzeService _analyzeService;

        public AnalyzeController(IAnalyzeService analyzeService)
        {
            _analyzeService = analyzeService;
        }



        [HttpPost("Analyze")]
        public IActionResult Analyze(AnalyzeRequest analyzeRequest)
        {
            var response = _analyzeService.AnalyzeData(analyzeRequest, Account);
            return Ok(response);
        }



        [HttpGet("GetUsersAnalyzedData")]
        public IActionResult GetUsersAnalyzedData(  [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _analyzeService.GetAnalyzedData( filter, route,Account);
            return Ok(response);
        }


        [HttpPost("RequestForExport")]
        public IActionResult RequestForExport([FromBody] ParameterId parameter) 
        { 
            var response = _analyzeService.RequestForExport(parameter.Id,  Account);
            return Ok(response);
        }



        [HttpPost("RejectExport")]
        public IActionResult RejectExport([FromBody] ParameterId parameter)
        {
            var response = _analyzeService.RejectExport(parameter.Id, Account);
            return Ok(response);
        }


        [HttpPost("ApproveExport")]
        public IActionResult ApproveExport([FromBody] ParameterId parameter)
        {
            var response = _analyzeService.ApproveExport(parameter.Id, Account);
            return Ok(response);
        }


        [HttpPost("GetExportRequest")]
        public IActionResult GetExportRequest([FromBody] ParameterId parameter, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _analyzeService.GetExportRequest(parameter.Id, filter, route, Account);
            return Ok(response);
        }



        [HttpPost("ExportAnalyzedData")]
        public IActionResult ExportAnalyzedData(ParameterId parameter)
        {
       
            var response = _analyzeService.ExportAnalyzedData(parameter.Id, Account);
            return Ok(response);
        }


        [HttpGet("GetAnalysisById")]
        public IActionResult GetAnalysisById([FromQuery] ParameterId parameter)
        {
            var response = _analyzeService.GetAnalysisById(parameter.Id);
            return Ok(response);
        }



    }
}
