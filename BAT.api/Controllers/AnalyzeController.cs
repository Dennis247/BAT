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
        private readonly IFileUploadService _fileUploadService;

        public AnalyzeController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }



        [HttpPost("Analyze")]
        public IActionResult PreviewFile(IFormFile file)
        {
            var response = _fileUploadService.PreviewFile(file, Account.Id);
            return Ok(response);
        }


 

    }
}
