using System;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Create(T value);
    }
}
