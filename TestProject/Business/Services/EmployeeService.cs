using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Interfaces.Service;
using Entities;
using Data;
using Dto;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeService(IMapper map)
        {
            this.unitOfWork = new UnitOfWork();
            this.mapper = map;
        }

        public void Create(EmployeeInformationDto value)
        {
            if (value != null)
            {
                var employee = mapper.Map<EmployeeInformationDto, Employee>(value);
                var career = mapper.Map<EmployeeInformationDto, CareerHistory>(value);

                unitOfWork.EmployeeRepository.Create(employee);
                unitOfWork.CareerRepository.Create(career);
            }
        }

        public EmployeeInformationDto Get(int id)
        {
            EmployeeInformationDto dto = null;
            var employee = unitOfWork.EmployeeRepository.Get(id);

            if (employee != null)
            {
                var actualPosition = GetEmployeeActualPosition(employee.Id);

                dto = mapper.Map<Employee, EmployeeInformationDto>(employee);
                dto = mapper.Map<CareerHistory, EmployeeInformationDto>(actualPosition);
            }

            return dto;
        }

        public IEnumerable<EmployeeInformationDto> GetAll()
        {
            IList<CareerHistory> careers = new List<CareerHistory>();
            var employeeList = unitOfWork.EmployeeRepository.GetAll();

            foreach(Employee em in employeeList)
            {
                careers.Add(GetEmployeeActualPosition(em.Id));
            }

            var dtoList = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeInformationDto>>(employeeList);
            dtoList = mapper.Map<IEnumerable<CareerHistory>, IEnumerable<EmployeeInformationDto>>(careers);

            return dtoList;
        }

        private CareerHistory GetEmployeeActualPosition(int employeeId)
        {
            var careerList = unitOfWork.CareerRepository.GetAll()
                    .Where(em => em.EmployeeId == employeeId)
                    .OrderByDescending(d => d.DismissalDate);

            var position = careerList.Where(p => p.DismissalDate == null).FirstOrDefault();
            var actualPosition = position ?? careerList.FirstOrDefault();

            return actualPosition;
        }
    }
}
