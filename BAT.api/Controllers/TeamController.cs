using BAT.api.Authorization;
using BAT.api.Models.Dtos.TeamDtos;
using BAT.api.Models.enums;
using BAT.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAT.api.Controllers
{
   
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamController : BaseController
    {
        private readonly ITeamServices _teamServices;

        public TeamController(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }


        [HttpPost("AddTeam")]
        public IActionResult AddTeam(AddTeam model)
        {
            var response = _teamServices.AddTeam(model, Account.Id);

            return Ok(response);
        }


   
        [HttpGet("GetAllTeams")]
        public IActionResult GetAllTeams()
        {
            var response = _teamServices.GetAllTeams();

            return Ok(response);
        }


        [HttpPost("AddAdminToTeam")]
        public IActionResult AddAdminToTeam(AddAdminToTeam model)
        {
            var response = _teamServices.AddAdminToTeam(model, Account.Id);

            return Ok(response);
        }

        [HttpPost("UpdateTeam")]
        public IActionResult UpdateTeam(UpdateTeam updateTeam)
        {
            var response = _teamServices.UpdateTeam(updateTeam, Account.Id);

            return Ok(response);
        }


        [HttpPost("UpdateTeamPermissions")]
        public IActionResult UpdateTeamPermissions(UpdateTeamPermission updateTeamPermission)
        {
            var response = _teamServices.UpdateTeamPermissions(updateTeamPermission, Account.Id);
            return Ok(response);
        }

        [HttpPost("GetTeamsWithUsersAndPriviledges")]
        public IActionResult GetTeamsWithUsersAndPriviledges(TeamDetailsId teamDetailsId)
        {
            var response = _teamServices.GetTeamsWithUsersAndPriviledges(teamDetailsId);
            return Ok(response);
        }
    }
}
