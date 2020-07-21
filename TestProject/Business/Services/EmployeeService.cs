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
                unitOfWork.EmployeeRepository.Create(employee);
            }
        }

        public EmployeeInformationDto Get(int id)
        {
            EmployeeInformationDto dto = null;
            var employee = unitOfWork.EmployeeRepository.Get(id);

            if (employee != null)
            {
                var actualPosition = GetEmployeeActualPosition(employee);

                dto = mapper.Map<Employee, EmployeeInformationDto>(employee,
                    opt => opt.Items["careerHistory"] = actualPosition);
            }

            return dto;
        }

        public IEnumerable<EmployeeInformationDto> GetAll()
        {
            var dtoList = new List<EmployeeInformationDto>();
            var employeeList = unitOfWork.EmployeeRepository.GetAll();
            CareerHistory actualPosition = null;
            EmployeeInformationDto temp = null;

            foreach (Employee em in employeeList)
            {
                actualPosition = GetEmployeeActualPosition(em);
                temp = mapper.Map<Employee, EmployeeInformationDto>(em,
                    opt => opt.Items["careerHistory"] = actualPosition);

                dtoList.Add(temp);
            }

            return dtoList;
        }

        private CareerHistory GetEmployeeActualPosition(Employee employee)
        {
            var careerList = employee.Career.OrderByDescending(d => d.DismissalDate);
            var position = careerList.Where(p => p.DismissalDate == null).FirstOrDefault();
            var actualPosition = position ?? careerList.FirstOrDefault();

            return actualPosition;
        }
    }
}
