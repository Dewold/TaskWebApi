using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T value);
    }
}
