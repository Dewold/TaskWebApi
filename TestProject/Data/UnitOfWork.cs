using System;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly EmployeeManagementContext context;
        private readonly PositionRepository positionRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly CareerRepository careerRepository;
        private bool disposed;

        public UnitOfWork()
        {
            this.context = new EmployeeManagementContext();
            this.positionRepository = new PositionRepository(context);
            this.employeeRepository = new EmployeeRepository(context);
            this.careerRepository = new CareerRepository(context);
            this.disposed = false;
        }

        #region Repositories
        public PositionRepository PositionRepository
        {
            get { return this.positionRepository; }
        }

        public EmployeeRepository EmployeeRepository
        {
            get { return this.employeeRepository; }
        }

        public CareerRepository CareerRepository
        {
            get { return this.careerRepository; }
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
