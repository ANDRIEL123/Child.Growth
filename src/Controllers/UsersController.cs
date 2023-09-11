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
        public List<Users> Get()
        {
            return _usersService.GetAll();
        }

        [HttpPost]
        [Authorize]
        public ResponseBody Create([FromBody] Users user)
        {
            return _usersService.Create(user);
        }

        [HttpPut]
        [Authorize]
        public ResponseBody Update([FromBody] Users user)
        {
            return _usersService.Update(user);
        }

        [HttpDelete]
        [Authorize]
        public ResponseBody Delete(long id)
        {
            return _usersService.Delete(id);
        }
    }
}