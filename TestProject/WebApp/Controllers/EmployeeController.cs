using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return new List<EmployeeInformationDto>();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
