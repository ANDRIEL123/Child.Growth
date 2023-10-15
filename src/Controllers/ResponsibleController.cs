using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsibleController : ControllerBase
    {
        private readonly ILogger<ResponsibleController> _logger;

        private readonly IResponsibleService _responsibleService;

        public ResponsibleController(
            ILogger<ResponsibleController> logger,
            IResponsibleService responsibleService
        )
        {
            _logger = logger;
            _responsibleService = responsibleService;
        }

        [HttpGet]
        [Authorize]
        public ResponseBody Get()
        {
            return _responsibleService.GetAll();
        }

        [HttpGet("GetByFilters")]
        [Authorize]
        public List<Responsible> GetByFilters(string filters)
        {
            var responsibleByFilter = _responsibleService.GetByFilters(filters);

            return responsibleByFilter;
        }

        [HttpGet("GetOptions")]
        [Authorize]
        public ResponseBody GetOptions()
        {
            return _responsibleService
                .GetOptions();
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Responsible entity)
        {
            return _responsibleService.CreateUserAndResponsible(entity);
        }

        [HttpPut]
        [Authorize]
        public ResponseBody Update([FromBody] Responsible entity)
        {
            return _responsibleService.Update(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ResponseBody Delete(long id)
        {
            return _responsibleService.DeleteUserAndResponsible(id);
        }
    }
}