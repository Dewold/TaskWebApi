using AutoMapper;
using Entities;
using Dto;
using Utilities.Automapper.Resolvers;

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

                c.CreateMap<EmployeeInformationDto, Employee>().ConvertUsing(new EmployeeInformationDtoToEmployeeResolver());
                c.CreateMap<Employee, EmployeeInformationDto>().ConvertUsing(new EmployeeToEmployeeInformationDtoResolver());
            });

            Mapper = config.CreateMapper();
        }
    }
}
