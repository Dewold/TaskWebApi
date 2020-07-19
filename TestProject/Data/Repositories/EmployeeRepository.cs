using System;
using System.Collections.Generic;
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

        public void Create(Employee value)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
