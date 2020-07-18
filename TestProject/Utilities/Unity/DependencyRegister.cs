using Unity;
using Entities;
using Data.Repositories;
using Interfaces.Repository;

namespace Utilities.Unity
{
    public class DependencyRegister
    {
        private UnityContainer container;

        public DependencyRegister()
        {
            container = new UnityContainer();
        }

        public UnityContainer ApplyDependencies()
        {
            container.RegisterType<IRepository<Position>, PositionRepository>();

            return container;
        }
    }
}
