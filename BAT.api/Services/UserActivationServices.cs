using AutoMapper;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.UserActivationDto;
using BAT.api.Models.Entities;
using BAT.api.Models.Response;
using BAT.api.Services;
using BAT.api.Utils.Helpers;
using Microsoft.Extensions.Options;

namespace BAT.api.Services
{

    public interface IUserActivationServices
    {
        Response<string> AddActivatedUsers(AddActivatedUser addActivatedUser);
        Response<List<UserActivationDto>> GetActivatedUsers();
    }
    public class UserActivationServices : IUserActivationServices
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;
    private readonly IEmailService _emailService;

    public UserActivationServices(
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
    public Response<string> AddActivatedUsers(AddActivatedUser addActivatedUser)
    {
        //check if user has been 
        var existing = _context.UserActivations.FirstOrDefault(x => x.Name.ToLower().Trim() == addActivatedUser.Name.ToLower().Trim()
        &&  x.PhoneNumber.Trim() == addActivatedUser.PhoneNumber.Trim());

        if (existing == null)
        {
            _context.UserActivations.Add(new UserActivation
            {
                PhoneNumber = addActivatedUser.PhoneNumber,
                DateActivated = DateTime.UtcNow,
                Name = addActivatedUser.Name,
            });

            _context.SaveChanges();
        }

        return new Response<string>
        {
            Data = "",
            Message = "Your souvenir request was successful",
            Succeeded = true
        };
    }

    public Response<List<UserActivationDto>> GetActivatedUsers()
    {
        var activations = _context.UserActivations.ToList();
        var userActivationsToReturn = _mapper.Map<List<UserActivationDto>>(activations);
        return new Response<List<UserActivationDto>>
        {
            Data = userActivationsToReturn,
            Message = "Sucessful",
            Succeeded = true
        };
    }
}
}
