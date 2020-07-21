using AutoMapper;
using Dto;
using Entities;

namespace Utilities.Automapper.Resolvers
{
    public class EmployeeInformationDtoToEmployeeResolver : ITypeConverter<EmployeeInformationDto, Employee>
    {
        public Employee Convert(EmployeeInformationDto source, Employee destination, ResolutionContext context)
        {
            var employee = new Employee()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Salary = source.Salary
            };

            employee.Career.Add(new CareerHistory()
            {
                HireDate = source.HireDate,
                DismissalDate = source.DismissalDate,
                PositionId = source.Position.Id,
                EmployeeId = source.EmployeeId
            });

            return employee;
        }
    }
}
