using System.Collections.Generic;
using Dto;

namespace Interfaces.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeInformationDto> GetAll();
        EmployeeInformationDto Get(int id);
        void Create(EmployeeInformationDto value);
    }
}
