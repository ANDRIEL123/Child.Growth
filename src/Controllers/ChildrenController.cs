using Child.Growth.src.Controllers.Base;
using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildrenController : AppControllerBase
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
        [Authorize(Roles = "Doctor")]
        public ResponseBody Get()
        {
            return _childrenService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor")]
        public ResponseBody GetById(long id)
        {
            return _childrenService.GetById(id);
        }

        [HttpGet("GetByFilters")]
        [Authorize(Roles = "Doctor")]
        public List<Children> GetByFilters(string filters)
        {
            var ChildrenByFilter = _childrenService.GetByFilters(filters);

            return ChildrenByFilter;
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Create([FromBody] Children entity)
        {
            return _childrenService.Create(entity);
        }

        [HttpPut]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Update([FromBody] Children entity)
        {
            return _childrenService.Update(entity);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Delete(long id)
        {
            return _childrenService.Delete(id);
        }
    }
}