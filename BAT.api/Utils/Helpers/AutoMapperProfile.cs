namespace BAT.api.Helpers;
using AutoMapper;
using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.Dtos.Candidate;
using BAT.api.Models.Dtos.FileUpload;
using BAT.api.Models.Dtos.PermissionDtos;
using BAT.api.Models.Dtos.TeamDtos;
using BAT.api.Models.Dtos.UserActivationDto;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public class AutoMapperProfile : Profile
{
    // mappings between model and entity objects
    public AutoMapperProfile()
    {
        CreateMap<Account, AccountResponse>();

        CreateMap<Account, AuthenticateResponse>();

        CreateMap<RegisterRequest, Account>();

        CreateMap<CreateRequest, Account>();

        CreateMap<UpdateRequest, Account>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));


        CreateMap<CandidateDto, Candidate>();
        CreateMap<Candidate, CandidateDto>().ForMember(x => x.CandidateImage, opt => opt.MapFrom<CandidateResolver>());

        CreateMap<AddCandidateDto, Candidate>();

        CreateMap<PermissionDto, Permission>();
        CreateMap<Permission, PermissionDto>();

        CreateMap<TeamDetails, Team>();
        CreateMap<Team, TeamDetails>();

        CreateMap<UserActivationDto, UserActivation>();
        CreateMap<UserActivation, UserActivationDto>();

        CreateMap<FileUpload, FileUploadDto>();
        CreateMap<FileUpload, FileUploadDto>().ForMember(x => x.DownloadUrl, opt => opt.MapFrom<FileUploadResolver>());

        CreateMap<UserData, UserDataDto>();

        CreateMap<UserData, UserImportlDataDto>();
        CreateMap<UserImportlDataDto, UserData>();



    }



    public class CandidateResolver : IValueResolver<Candidate, CandidateDto, string>
    {
        private readonly AppSettings _appSettings;

        public CandidateResolver(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Resolve(Candidate source, CandidateDto target, string destMember, ResolutionContext context)
        {
            return $"{_appSettings.BaseUrl}{source.CandidateImage}";
        }
    }


    public class FileUploadResolver : IValueResolver<FileUpload, FileUploadDto, string>
    {
        private readonly AppSettings _appSettings;

        public FileUploadResolver(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Resolve(FileUpload source, FileUploadDto target, string destMember, ResolutionContext context)
        {
            return $"{_appSettings.BaseUrl}{source.DownloadUrl}";
        }
    }
}