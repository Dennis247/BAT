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



        //[HttpPost("UploadUserData")]
        //public IActionResult UploadUserData(IFormFile file)
        //{
        //    var response = _fileUploadService.UploadUserData(file, Account.Id);
        //    return Ok(response);
        //}


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


        //[HttpPost("MergeUserData")]
        //public IActionResult MergeUserData(MergeUserDataDto mergeUserDataDto)
        //{
        //    var route = Request.Path.Value;
        //    var response = _fileUploadService.MergeUserData(mergeUserDataDto, Account.Id);
        //    return Ok(response);
        //}




    }
}
