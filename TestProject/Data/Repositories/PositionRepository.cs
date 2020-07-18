using System;
using System.Collections.Generic;
using Entities;
using Interfaces.Repository;

namespace Data.Repositories
{
    public class PositionRepository : IRepository<Position>
    {
        public bool Create(Position position)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Position Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
