using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildrenController : ControllerBase
    {
        private readonly ILogger<ChildrenController> _logger;

        private readonly IChildrenService _childrenService;

        public ChildrenController(
            ILogger<ChildrenController> logger,
            IChildrenService childrenService
        )
        {
            _logger = logger;
            _childrenService = childrenService;
        }

        [HttpGet]
        [Authorize]
        public ResponseBody Get()
        {
            return _childrenService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ResponseBody GetById(long id)
        {
            return _childrenService.GetById(id);
        }

        [HttpGet("GetByFilters")]
        [Authorize]
        public List<Children> GetByFilters(string filters)
        {
            var ChildrenByFilter = _childrenService.GetByFilters(filters);

            return ChildrenByFilter;
        }

        [HttpPost]
        [Authorize]
        public ResponseBody Create([FromBody] Children user)
        {
            return _childrenService.Create(user);
        }

        [HttpPut]
        [Authorize]
        public ResponseBody Update([FromBody] Children user)
        {
            return _childrenService.Update(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ResponseBody Delete(long id)
        {
            return _childrenService.Delete(id);
        }
    }
}