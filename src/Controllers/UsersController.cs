using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
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

        [HttpGet]
        [Authorize]
        public List<Users> Get()
        {
            return _usersService.GetAll().ToList();
        }

        [HttpGet("auth")]
        public string Auth(string email)
        {
            return _tokenService.GenerateToken(email);
        }

        [HttpPost]
        public void Create([FromBody] Users user)
        {
            _usersService.Create(user);
        }
    }
}