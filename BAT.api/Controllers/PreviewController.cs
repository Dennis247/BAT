using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Services;
using BAT.api.Utils.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : BaseController
    {
        private readonly IFileUploadService _fileUploadService;

        public PreviewController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }



        [HttpPost("PreviewFile")]
        public IActionResult PreviewFile(IFormFile file)
        {
            var response = _fileUploadService.PreviewFile(file, Account.Id);
            return Ok(response);
        }


        [HttpGet("GetUsersPreviewedFiles")]
        public IActionResult GetUsersPreviewedFiles([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.GetUserPreviewedFiles(filter, Account.Id, route);
            return Ok(response);
        }

        [HttpPost("ViewFileContents")]
        public IActionResult ViewFileContents([FromBody] ViewFileId fileId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = _fileUploadService.ViewFileContents(fileId.FileId, filter, route);
            return Ok(response);
        }


        [HttpPost("SavePreviewedFile")]
        public IActionResult SavePreviewedFile(ViewFileId FileId)
        {
            var response = _fileUploadService.SavePreviewedFile(FileId.FileId);
            return Ok(response);
        }


    }
}
