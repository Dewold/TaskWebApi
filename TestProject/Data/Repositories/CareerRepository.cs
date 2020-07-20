using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entities;
using Interfaces.Repository;

namespace Data.Repositories
{
    public class CareerRepository : IRepository<CareerHistory>
    {
        private EmployeeManagementContext context;

        public CareerRepository(EmployeeManagementContext con)
        {
            this.context = con;
        }

        public void Create(CareerHistory value)
        {
            context.Careers.Add(value);
            context.SaveChanges();
        }

        public CareerHistory Get(int id)
        {
            return context.Careers
               .Include(p => p.Position)
               .Where(p => p.Id == id)
               .FirstOrDefault();
        }

        public IEnumerable<CareerHistory> GetAll()
        {
            return context.Careers
                .Include(p => p.Position);
        }
    }
}
