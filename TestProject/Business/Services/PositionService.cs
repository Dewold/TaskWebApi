using System.Collections.Generic;
using AutoMapper;
using Interfaces.Service;
using Entities;
using Data;
using Dto;

namespace Business.Services
{
    public class PositionService : IPositionService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PositionService(IMapper map)
        {
            this.unitOfWork = new UnitOfWork();
            this.mapper = map;
        }

        public void Create(PositionDto value)
        {
            if (value != null)
            {
                var position = mapper.Map<PositionDto, Position>(value);
                unitOfWork.PositionRepository.Create(position);
            }
        }

        public PositionDto Get(int id)
        {
            var position = unitOfWork.PositionRepository.Get(id);
            var dto = mapper.Map<Position, PositionDto>(position);
            return dto;
        }

        public IEnumerable<PositionDto> GetAll()
        {
            var list = unitOfWork.PositionRepository.GetAll();
            var dtoList = mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(list);
            return dtoList;
        }
    }
}
