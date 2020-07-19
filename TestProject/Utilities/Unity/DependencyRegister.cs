using Unity;
using Entities;
using Data.Repositories;
using Business.Services; 
using Interfaces.Repository;
using Interfaces.Service;
using Utilities.Automapper;

namespace Utilities.Unity
{
    public class DependencyRegister
    {
        private UnityContainer container;
        private MapperConfig mapper;

        public DependencyRegister()
        {
            container = new UnityContainer();
            mapper = new MapperConfig();
        }

        public UnityContainer ApplyDependencies()
        {
            container.RegisterInstance(mapper.Mapper);

            container.RegisterType<IRepository<Position>, PositionRepository>();

            container.RegisterType<IPositionService, PositionService>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            return container;
        }
    }
}
