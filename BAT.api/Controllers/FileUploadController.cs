using BAT.api.Authorization;
using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Services;
using BAT.api.Utils.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : BaseController
    {

        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }



        [AllowAnonymous]
        [HttpPost("GetUserUploads")]
        public IActionResult GetUserUploads([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.GetUserFileUploads(filter, route, Account);
            return Ok(response);
        }

        [HttpPost("ViewUserUploads")]
        public IActionResult ViewUserUploads([FromBody] ViewFileId fileId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.ViewUserUploadData(fileId.FileId, filter, route);
            return Ok(response);
        }


        [HttpPost("DeleteFile")]
        public IActionResult DeleteFile( ViewFileId fileId)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.DeleteFile(fileId.FileId);
            return Ok(response);
        }




        [HttpPost("UpdateFile")]
        public async Task<IActionResult> UpdateFile([FromForm] UpdateFile updateFile)
        {
            var response = await _fileUploadService.UpdateFile(updateFile, Account);
            return Ok(response);
        }



        [HttpPost("MergeFiles")]
        public IActionResult MergeFiles(MergeDataDto mergeDataDto)
        {
            var response = _fileUploadService.MergeUserData(mergeDataDto, Account.Id);
            return Ok(response);
        }



        [HttpGet("GetUploadErrors")]
        public IActionResult GetUploadErrors([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.GetUploadedErrors(filter, route, Account);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(int FileId)
        {
            var response = _fileUploadService.DownloadFile(FileId);
            return File(response.DOwnloadData, System.Net.Mime.MediaTypeNames.Application.Octet, response.FileName);
        }


        [AllowAnonymous]
        [HttpGet("DownloadFileUsingFields")]
        public IActionResult DownloadFileUsingFields(int FileId)
        {
            var response = _fileUploadService.DownloadFileUsingFields(FileId);
            return File(response.DOwnloadData, System.Net.Mime.MediaTypeNames.Application.Octet, response.FileName);
        }

    }
}
