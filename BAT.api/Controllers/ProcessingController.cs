using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Services;
using BAT.api.Utils.Filters;
using BAT.api.Utils.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProcessingController : BaseController
    {

        private readonly IFileUploadService _fileUploadService;

        public ProcessingController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }



        //[HttpPost("UploadUserData")]
        //public IActionResult UploadUserData(IFormFile file)
        //{
        //    var response = _fileUploadService.UploadUserData(file, Account.Id);
        //    return Ok(response);
        //}


        //[HttpPost("GetUserUploads")]
        //public IActionResult GetUserUploads([FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var response = _fileUploadService.GetUserFileUploads(filter, route, Account);
        //    return Ok(response);
        //}

        //[HttpPost("ViewUserUploads")]
        //public IActionResult ViewUserUploads( [FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var response = _fileUploadService.ViewUserUploadData(fileId.FileId, filter, route);
        //    return Ok(response);
        //}


        [HttpGet("GetProcessedFiles")]
        public IActionResult GetProcessedFiles([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response =  _fileUploadService.GetProcessedFiles(filter, route, Account);
            return Ok(response);
        }

        [HttpGet("GetProcessById")]
        public IActionResult GetProcessById([FromQuery] ParameterId parameter)
        {
            var response = _fileUploadService.GetProcessedFileById(parameter.Id);
            return Ok(response);
        }

        [HttpPost("ProcessFile")]
        public async Task<IActionResult> ProcessFile(ProcessFileRequest queries)
        {
            var route = Request.Path.Value;
            queries.FileName = $"Proc_{queries.FileName}";
            var response = await _fileUploadService.ProcessFile(queries, Account);
            return Ok(response);
        }

        [HttpPost("ViewFileContents")]
        public IActionResult ViewFileContents([FromBody] ViewFileId fileId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.ViewProcessedFileContents(fileId.FileId, filter, route);
            return Ok(response);
        }


    }
}
