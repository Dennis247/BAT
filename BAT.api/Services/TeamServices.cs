using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.TeamDtos;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using Microsoft.Extensions.Options;

namespace BAT.api.Services
{
    public interface ITeamServices
    {
        Response<string> AddAdminToTeam(AddAdminToTeam addAdminToTeam,int AddedBy);
        public Response<int> AddTeam(AddTeam addTeam, int AdminId);
        Response<List<Team>> GetAllTeams();
        Response<TeamDetails> UpdateTeam(UpdateTeam updateTeam, int AdminId);
        Response<string> UpdateTeamPermissions(UpdateTeamPermission updateTeamPermission, int AdminId);
    }


    public class TeamServices : ITeamServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public TeamServices(
            ApplicationDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }
        public Response<string> AddAdminToTeam(AddAdminToTeam addAdminToTeam, int AddedBy)
        {
            var existingAdmin = _context.Accounts.SingleOrDefault(x => x.Id == addAdminToTeam.AdminId);
            if (existingAdmin == null)
                throw new AppException("Admin is not valid");
            var existingTeam = _context.Teams.SingleOrDefault(x => x.Id == addAdminToTeam.TeamId);
            if (existingTeam == null)
                throw new AppException("Team is not valid");

            AdminTeam adminTeam = new AdminTeam
            {
                AddedBy = AddedBy,
                AdminId = addAdminToTeam.AdminId,
                Created = DateTime.UtcNow,
                TeamId = addAdminToTeam.TeamId,
            };

            _context.AdminTeams.Add(adminTeam);
            _context.SaveChanges();

            return new Response<string>
            {
                Data = "",
                Message = "Admin added to team Sucessful",
                Succeeded = true,
            };
        }

        public Response<List<Team>> GetAllTeams()
        {
            var allTeams = _context.Teams.ToList();
            return new Response<List<Team>>
            {
                Data = allTeams,
                Succeeded = true,
                Message = "sucessful"

            };
        }

        public Response<TeamDetails> UpdateTeam(UpdateTeam updateTeam, int AdminId)
        {
            var existingTeam = _context.Teams.SingleOrDefault(x => x.Id == updateTeam.TeamId);
            if (existingTeam == null)
                throw new AppException("Team is not valid");

            existingTeam.Name = updateTeam.Name;
            existingTeam.LastTimeUpdated = DateTime.UtcNow;
            existingTeam.ModifiedBy = AdminId;

            _context.Teams.Update(existingTeam);
            _context.SaveChanges();

            var teamToReturn = _mapper.Map<TeamDetails>(existingTeam);

            return new Response<TeamDetails>
            {
                Data = teamToReturn,
                Succeeded = true,
                Message = "update sucessful"

            };

        }

        public Response<int> AddTeam(AddTeam addTeam, int AdminId)
        {
            var existingTeam = _context.Teams.SingleOrDefault(x => x.Name == addTeam.Name);
            if (existingTeam == null)
                throw new AppException("Team already exist");

            var newTeam = new Team
            {
                Name = addTeam.Name,
                Created = DateTime.UtcNow,
                CretaedBy = AdminId,
            };


            _context.Teams.Add(newTeam);
            _context.SaveChanges();


            //add team priviledges
            List<TeamPermission> teamPermissions = new List<TeamPermission>();


            //add only valid permissions
            var existingPermissions = _context.Permissions.Select(x => x.Id);
            var validPermissions = addTeam.PriviledgesId.Where(x => existingPermissions.Contains(x));
            foreach (var item in validPermissions)
            {
                teamPermissions.Add(new TeamPermission
                {
                    Created = DateTime.UtcNow,
                    CreatedBy = AdminId,
                    PermissionId = item,
                    TeamId = newTeam.Id
                });
            }

            //add user Team
            List<AdminTeam> adminTeams = new List<AdminTeam>();
            var existingAdminIds = _context.Accounts.Select(x => x.Id);
            var validAdminIds = addTeam.AdminIds.Where(x => existingAdminIds.Contains(x));
            foreach (var user in validAdminIds)
            {
                adminTeams.Add(new AdminTeam { 
                    AddedBy = AdminId,
                    Created = DateTime.UtcNow,
                    TeamId = newTeam.Id,
                    AdminId = user,
                   
                });
            }

            _context.TeamPermissions.AddRange(teamPermissions);
            _context.AdminTeams.AddRange(adminTeams);
            _context.SaveChanges();

            return new Response<int>
            {
                Data = newTeam.Id,
                Succeeded = true,
                Message = "Team created sucessful"

            };

        }

        public Response<string> UpdateTeamPermissions(UpdateTeamPermission updateTeamPermission, int AdminId)
        {
            //get all existing Team permissions
            var existingTeam = _context.Teams.SingleOrDefault(x => x.Id == updateTeamPermission.TeamId);
            if (existingTeam == null)
                throw new AppException("Team is not valid");

            var oldPermissions = _context.TeamPermissions.Where(x => x.TeamId == updateTeamPermission.TeamId).ToList();
            _context.TeamPermissions.RemoveRange(oldPermissions);

            var existingPermissions = _context.Permissions;


            List<TeamPermission> teamPermissions = new List<TeamPermission>();
            foreach (var permissionId in updateTeamPermission.Permissions)
            {
                if (existingPermissions.Select(x => x.Id).Contains(permissionId))
                    teamPermissions.Add(new TeamPermission { 
                        PermissionId = permissionId, 
                        TeamId = updateTeamPermission.TeamId ,
                        Created = DateTime.UtcNow,
                        CreatedBy = AdminId
                    });
            }

            _context.TeamPermissions.AddRange(teamPermissions);
            _context.SaveChanges();

            var teamToReturn = _mapper.Map<TeamDetails>(existingTeam);

            return new Response<string>
            {
                Data = "",
                Succeeded = true,
                Message = "update sucessful"

            };
        }

  
    }
}
