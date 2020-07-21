using AutoMapper;
using Dto;
using Entities;

namespace Utilities.Automapper.Resolvers
{
    public class EmployeeToEmployeeInformationDtoResolver : ITypeConverter<Employee, EmployeeInformationDto>
    {
        public EmployeeInformationDto Convert(Employee source, EmployeeInformationDto destination, ResolutionContext context)
        {
            CareerHistory careerHistory = context.Options.Items["careerHistory"] as CareerHistory;

            var dto = new EmployeeInformationDto()
            {
                EmployeeId = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Salary = source.Salary,
                Id = careerHistory.Id,
                HireDate = careerHistory.HireDate,
                DismissalDate = careerHistory.DismissalDate,
                Position = new PositionDto {
                    Id = careerHistory.Position.Id,
                    Name = careerHistory.Position.Name
                }
            };

            return dto;
        }
    }
}
