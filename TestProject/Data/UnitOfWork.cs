using System;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeManagementContext context;
        private PositionRepository positionRepository;
        private bool disposed;

        public UnitOfWork()
        {
            this.context = new EmployeeManagementContext();
            this.disposed = false;
        }

        #region Repositories
        public PositionRepository PositionRepository
        {
            get
            {
                return this.positionRepository ??
                    new PositionRepository(context);
            }
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
