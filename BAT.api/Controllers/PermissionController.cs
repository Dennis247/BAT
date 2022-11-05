using BAT.api.Authorization;
using BAT.api.Models.Entities;
using BAT.api.Models.enums;
using BAT.api.Services;
using BAT.api.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
 //   [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : BaseController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("GetAllPermissions")]
        public IActionResult GetAllPermissions()
        {

            var allPermissions = _permissionService.GetAllPermissions();
            return Ok(allPermissions);
        }
    }
}
