using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Child.Growth.src.Data;
using Child.Growth.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Child.Growth.src.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly ApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<Users> Get()
        {
            var users = _context.Users
                .ToList();

            return users;
        }
    }
}