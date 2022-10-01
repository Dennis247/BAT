using BAT.api.Authorization;
using BAT.api.Models.Dtos.UserActivationDto;
using BAT.api.Models.Entities;
using BAT.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class UserActivationController : BaseController
    {
        private readonly IUserActivationServices _userActivationServices;

        public UserActivationController(IUserActivationServices userActivationServices)
        {
            _userActivationServices = userActivationServices;
        }

        [AllowAnonymous]
        [HttpGet("GetAllUserActivations")]
        public IActionResult GetAllUserActivations()
        {
            var allPermissions = _userActivationServices.GetActivatedUsers();
            return Ok(allPermissions);
        }

        [AllowAnonymous]
        [HttpPost("AddUserActivation")]
        public IActionResult AddUserActivation(AddActivatedUser addActivatedUser)
        {
            var allPermissions = _userActivationServices.AddActivatedUsers(addActivatedUser);
            return Ok(allPermissions);
        }

        [AllowAnonymous]
        [HttpGet("GetUserActivationDashBoard")]
        public IActionResult GetUserActivationDashBoard()
        {
            var allPermissions = _userActivationServices.GetUserActivationDashBoard();
            return Ok(allPermissions);
        }



        [AllowAnonymous]
        [HttpPost("GetUserActivationRange")]
        public IActionResult GetUserActivationRange(UserActivationRange userActivationRange)
        {
            var allPermissions = _userActivationServices.GetActivatedUsersRange(userActivationRange);
            return Ok(allPermissions);
        }

        [AllowAnonymous]
        [HttpPost("ExportActivatedUsers")]
        public IActionResult ExportActivatedUsers()
        {
            var allActivatedUsers  = _userActivationServices.ExportActivatedUsers();
            return File(allActivatedUsers, System.Net.Mime.MediaTypeNames.Application.Octet, "Activated Users List.xlsx");
        }
    }
}
