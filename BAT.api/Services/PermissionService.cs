using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.PermissionDtos;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using Microsoft.Extensions.Options;

namespace BAT.api.Services
{
    public interface IPermissionService
    {
        Response<List<PermissionDto>> GetAllPermissions();
    }



    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public PermissionService(
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


        public Response<List<PermissionDto>> GetAllPermissions()
        {
           var allPermissions = _context.Permissions.ToList();
            var permissionToReturn = _mapper.Map<List<PermissionDto>>(allPermissions);
            return new Response<List<PermissionDto>>
            {
                Data = permissionToReturn,
                Message ="sucessful",
                Succeeded = true
            };
        }
    }
}
