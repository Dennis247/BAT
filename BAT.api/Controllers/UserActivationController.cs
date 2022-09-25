using BAT.api.Authorization;
using BAT.api.Models.Dtos.UserActivationDto;
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
    }
}
