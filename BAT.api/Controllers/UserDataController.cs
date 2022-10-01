using BAT.api.Authorization;
using BAT.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BAT.api.Models.Dtos.UserData.UserImportlDataDto;

namespace BAT.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataController : BaseController
    {
        private readonly IUserDataService _userDataService;
        public UserDataController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }


        [AllowAnonymous]
        [HttpGet("GetUserDataDashBoard")]
        public IActionResult GetUserDataDashBoard()
        {
            var response = _userDataService.GetUserDataDashBoard();
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("GetUserDataWithRange")]
        public IActionResult GetUserDataWithRange(UserDashBoardRange userDashBoardRange)
        {
            var allPermissions = _userDataService.GetDashBoardRangeSearch(userDashBoardRange);
            return Ok(allPermissions);
        }

    }
}
