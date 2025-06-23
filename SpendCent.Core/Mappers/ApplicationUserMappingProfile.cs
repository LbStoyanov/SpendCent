using AutoMapper;
using SpendCent.Core.DTOs;
using SpendCent.Core.Entities;

namespace SpendCent.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{


    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserID, src => src.MapFrom(x => x.UserID))
            .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
            .ForMember(dest => dest.PersonName, src => src.MapFrom(x => x.PersonName))
            .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.Gender))
            .ForMember(dest => dest.Token, src => src.Ignore())
            .ForMember(dest => dest.Success, src => src.Ignore());
    }
}

