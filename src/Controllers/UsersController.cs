using Child.Growth.src.Entities;
using Child.Growth.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Child.Growth.src.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        public List<Users> Get()
        {
            return _usersService.GetAll().ToList();
        }

        [HttpPost]
        public void Create([FromBody] Users user)
        {
            _usersService.Create(user);
        }
    }
}