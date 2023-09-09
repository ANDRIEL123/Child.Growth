using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersService _usersService;
        private readonly ITokenService _tokenService;

        public UsersController(
            ILogger<UsersController> logger,
            IUsersService usersService,
            ITokenService tokenService
        )
        {
            _logger = logger;
            _usersService = usersService;
            _tokenService = tokenService;
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
        [Route("")]
        [Authorize]
        public List<Users> Get()
        {
            return _usersService.GetAll().ToList();
        }

        [HttpPost]
        [Route("")]
        public void Create([FromBody] Users user)
        {
            _usersService.Create(user);
        }
    }
}