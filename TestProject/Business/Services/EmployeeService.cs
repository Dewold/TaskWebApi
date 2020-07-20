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

                employee.Career = new List<CareerHistory>() { career };

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

                dto = new EmployeeInformationDto();
                mapper.Map<Employee, EmployeeInformationDto>(employee, dto);
                mapper.Map<CareerHistory, EmployeeInformationDto>(actualPosition, dto);
            }

            return dto;
        }

        public IEnumerable<EmployeeInformationDto> GetAll()
        {
            IList<CareerHistory> careers = new List<CareerHistory>();
            var dtoList = new List<EmployeeInformationDto>();
            var employeeList = unitOfWork.EmployeeRepository.GetAll();

            int count = 0;
            EmployeeInformationDto temp = null;

            foreach (Employee em in employeeList)
            {
                careers.Add(GetEmployeeActualPosition(em));

                temp = new EmployeeInformationDto
                {
                    FirstName = em.FirstName,
                    LastName = em.LastName,
                    EmployeeId = em.Id,
                    Salary = em.Salary,
                    Id = careers[count].Id,
                    HireDate = careers[count].HireDate,
                    DismissalDate = careers[count].DismissalDate,
                    Position = new PositionDto {
                        Id = careers[count].Position.Id,
                        Name = careers[count].Position.Name
                    }
                };

                dtoList.Add(temp);
                count++;
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
