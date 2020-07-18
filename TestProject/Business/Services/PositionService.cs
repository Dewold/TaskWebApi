using System.Collections.Generic;
using AutoMapper;
using Entities;
using Dto;
using Interfaces.Repository;
using Interfaces.Service;

namespace Business.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> repository;
        private readonly IMapper mapper;

        public PositionService(IRepository<Position> repo, IMapper map)
        {
            this.repository = repo;
            this.mapper = map;
        }

        public void Create(PositionDto value)
        {
            if (value != null)
            {
                var position = mapper.Map<PositionDto, Position>(value);
                repository.Create(position);
            }
        }

        public PositionDto Get(int id)
        {
            var position = repository.Get(id);
            var dto = mapper.Map<Position, PositionDto>(position);
            return dto;
        }

        public IEnumerable<PositionDto> GetAll()
        {
            var list = repository.GetAll();
            var dto = mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(list);
            return dto;
        }
    }
}
