using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Entities;
using Interfaces.Repository;

namespace Data.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private EmployeeManagementContext context;

        public EmployeeRepository(EmployeeManagementContext con)
        {
            this.context = con;
        }

        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public Employee Get(int id)
        {
            return context.Employees
               .Include(c => c.Career.Select(p => p.Position))
               .Where(p => p.Id == id)
               .FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees
                .Include(c => c.Career.Select(p => p.Position));
        }
    }
}
