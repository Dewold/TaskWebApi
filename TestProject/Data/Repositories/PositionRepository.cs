using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Entities;
using Interfaces.Repository;

namespace Data.Repositories
{
    public class PositionRepository : IRepository<Position>
    {
        private EmployeeManagementContext context;

        public PositionRepository(EmployeeManagementContext con)
        {
            this.context = con;
        }

        public void Create(Position position)
        {
            context.Positions.Add(position);
            context.SaveChanges();
        }

        public Position Get(int id)
        {
            return context.Positions
                .Where(p => p.Id == id)
                .FirstOrDefault();             
        }

        public IEnumerable<Position> GetAll()
        {
            return context.Positions;
        }
    }
}
