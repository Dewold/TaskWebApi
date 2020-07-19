using System.Collections.Generic;
using System.Web.Http;
using Dto;
using Interfaces.Service;

namespace WebApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.service = employeeService;
        }

        // GET: api/Employee
        public IEnumerable<EmployeeInformationDto> Get()
        {
            var list = service.GetAll();
            return list;
        }

        // GET: api/Employee/5
        public EmployeeInformationDto Get(int id)
        {
            var selected = service.Get(id);
            return selected;
        }

        // POST: api/Employee
        public void Post([FromBody] EmployeeInformationDto value)
        {
            service.Create(value);
        }
    }
}
