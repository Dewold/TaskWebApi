using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public CareerHistory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CareerHistory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
