using AutoMapper;
using Dal.Entities;
using Dal.ViewModels;

namespace Logic.AutoMapper;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Footballer, FootballerViewModel>().ReverseMap();

        CreateMap<Team, TeamViewModel>().ReverseMap()
            .ForMember(dest => dest.Footballers, opt => opt.Ignore());

        // CreateMap<string, TeamViewModel>()
        //     .ForMember(dest => dest.Id, opt => opt.Ignore())
        //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));
    }
}