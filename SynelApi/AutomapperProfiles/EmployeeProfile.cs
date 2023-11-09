using AutoMapper;
using SynelApi.Dtos;
using SynelApi.Entities;

namespace SynelApi.AutomapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeData>()
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Address2))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailHome))
                .ReverseMap();
        }
    }
}
