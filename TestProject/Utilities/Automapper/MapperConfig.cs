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
            });

            Mapper = config.CreateMapper();
        }
    }
}
