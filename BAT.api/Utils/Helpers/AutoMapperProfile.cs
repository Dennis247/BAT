namespace BAT.api.Helpers;
using AutoMapper;
using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.Dtos.Candidate;
using BAT.api.Models.Dtos.PermissionDtos;
using BAT.api.Models.Dtos.TeamDtos;
using BAT.api.Models.Dtos.UserActivationDto;
using BAT.api.Models.Entities;

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
        CreateMap<Candidate, CandidateDto>();
        CreateMap<AddCandidateDto, Candidate>();

        CreateMap<PermissionDto, Permission>();
        CreateMap<Permission, PermissionDto>();



        CreateMap<TeamDetails, Team>();
        CreateMap<Team, TeamDetails>();


        CreateMap<UserActivationDto, UserActivation>();
        CreateMap<UserActivation, UserActivationDto>();





    }
}