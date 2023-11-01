using Child.Growth.src.Entities;
using Child.Growth.src.Infra.Responses;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersService _usersService;

        public UsersController(
            ILogger<UsersController> logger,
            IUsersService usersService,
            ITokenService tokenService
        )
        {
            _logger = logger;
            _usersService = usersService;
        }

        /// <summary>
        /// Realiza o login na autenticação gerando o JWT Bearer Token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            return Ok(_usersService.Login(email, password));
        }

        [HttpGet]
        [Authorize]
        public ResponseBody Get()
        {
            return _usersService.GetAll();
        }

        [HttpGet("GetByFilters")]
        [Authorize(Roles = "Doctor, Responsible")]
        public List<Users> GetByFilters(string filters)
        {
            var usersByFilter = _usersService.GetByFilters(filters);

            return usersByFilter;
        }

        [HttpPost]
        public ResponseBody Create([FromBody] Users entity)
        {
            return _usersService.Create(entity);
        }

        [HttpPut]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Update([FromBody] Users entity)
        {
            return _usersService.Update(entity);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor")]
        public ResponseBody Delete(long id)
        {
            return _usersService.Delete(id);
        }
    }
}