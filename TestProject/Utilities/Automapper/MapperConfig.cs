using AutoMapper;
using Entities;
using Dto;

namespace Utilities.Automapper
{
    public class MapperConfig
    {
        private MapperConfiguration config;

        public IMapper Mapper { get; private set; }

        public MapperConfig()
        {
            config = new MapperConfiguration(c =>
            {
                c.CreateMap<Position, PositionDto>().ReverseMap();

                c.CreateMap<EmployeeInformationDto, Employee>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
                    .ReverseMap();

                c.CreateMap<EmployeeInformationDto, CareerHistory>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                    .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.PositionId))
                    .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate))
                    .ForMember(dest => dest.DismissalDate, opt => opt.MapFrom(src => src.DismissalDate))
                    .ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}
