using System.Collections.Generic;
using Dto;

namespace Interfaces.Service
{
    public interface IPositionService
    {
        IEnumerable<PositionDto> GetAll();
        PositionDto Get(int id);
        void Create(PositionDto value);
    }
}
