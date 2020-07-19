using System.Collections.Generic;
using System.Web.Http;
using Interfaces.Service;
using Dto;

namespace WebApp.Controllers
{
    public class PositionController : ApiController
    {
        private readonly IPositionService service;

        public PositionController(IPositionService positionService)
        {
            this.service = positionService;
        }

        // GET: api/Position
        public IEnumerable<PositionDto> Get()
        {
            var list = service.GetAll();
            return list;
        }

        // GET: api/Position/5
        public PositionDto Get(int id)
        {
            var selected = service.Get(id);
            return selected;
        }

        // POST: api/Position
        public void Post([FromBody] PositionDto value)
        {
            service.Create(value);
        }
    }
}
