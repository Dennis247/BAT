using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.Dtos.PermissionDtos;
using BAT.api.Models.Dtos.TeamDtos;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BAT.api.Services
{
    public interface ITeamServices
    {
        Response<string> AddAdminToTeam(AddAdminToTeam addAdminToTeam,int AddedBy);
        Response<int> AddTeam(AddTeam addTeam, int AdminId);
        Response<string> DeleteTeam(int Id);
        Response<List<TeamDetails>> GetAllTeams();
        Response<TeamDetails> UpdateTeam(UpdateTeam updateTeam, int AdminId);
        Response<string> UpdateTeamPermissions(UpdateTeamPermission updateTeamPermission, int AdminId);

        Response<TeamWithUserAndPriviledges> GetTeamsWithUsersAndPriviledges(TeamDetailsId teamDetailsId);
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

            //check if admin already belongs to team
            var adminExistinTeam = _context.AdminTeams.FirstOrDefault(x => x.AdminId == addAdminToTeam.AdminId
            && x.TeamId == addAdminToTeam.TeamId);
            if(adminExistinTeam != null)
            {
                throw new AppException("Admin has already been to this team");
            }

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

        public Response<List<TeamDetails>> GetAllTeams()
        {
            var allTeams = _context.Teams.ToList();
            var teamToReturn = _mapper.Map<List<TeamDetails>>(allTeams);
            return new Response<List<TeamDetails>>
            {
                Data = teamToReturn,
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
            if (existingTeam != null)
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


            return new Response<string>
            {
                Data = "",
                Succeeded = true,
                Message = "update sucessful"

            };
        }

        public Response<TeamWithUserAndPriviledges> GetTeamsWithUsersAndPriviledges(TeamDetailsId teamDetailsId)
        {
            TeamWithUserAndPriviledges teamWithUserAndPriviledges = new TeamWithUserAndPriviledges();
            var team = _context.Teams.FirstOrDefault(x => x.Id == teamDetailsId.TeamId);
            if (team == null)
                throw new AppException("Invalid Team Id");
            var teamPermissions = _context.TeamPermissions.Where(x=>x.TeamId == teamDetailsId.TeamId).ToList();
            var permissions = _context.Permissions.Where(pm => (teamPermissions.Select(x => x.PermissionId).Contains(pm.Id))).ToList();

            var permissionToReturn = _mapper.Map<List<PermissionDto>>(permissions);



            var teamAdmins = _context.AdminTeams.Where(x=>x.TeamId == teamDetailsId.TeamId).ToList();
            var accounts = _context.Accounts.Where(ac => (teamAdmins.Select(x => x.AdminId).Contains(ac.Id))).ToList();
            var accountsToReturn =_mapper.Map<List<AccountResponse>>(accounts);
            teamWithUserAndPriviledges = new TeamWithUserAndPriviledges
            {
                Id = team.Id,
                Created = team.Created,
                CretaedBy = team.CretaedBy,
                Name = team.Name,
                IsDeleted = team.IsDeleted,
                Accounts = accountsToReturn,
                Priviledges = permissionToReturn
            };

            return new Response<TeamWithUserAndPriviledges>
            {
                Data = teamWithUserAndPriviledges,
                Message = "sucessfull",
                Succeeded = true
            };
        }

        public Response<string> DeleteTeam(int Id)
        {
           var existingTeam = _context.Teams.AsNoTracking().FirstOrDefault(x => x.Id == Id);
            if(existingTeam == null)
                throw new KeyNotFoundException("Team not found");


            //delete all team permissions
            var allTeamsPermissions = _context.TeamPermissions.Where(x => x.TeamId == Id);

            //delete all userTeams
            var allUserTeams = _context.AdminTeams.Where(x=>x.TeamId == Id);

            _context.RemoveRange(allUserTeams);
            _context.RemoveRange(allTeamsPermissions);

            _context.SaveChanges();

            

            _context.Remove(existingTeam);
            _context.SaveChanges();

            return new Response<string>
            {
                Data = "",
                Message = "Team deleted sucessful",
                Succeeded = true
            };
            
        }
    }
}
