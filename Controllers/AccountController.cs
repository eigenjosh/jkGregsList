using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GregsList.Models;
using GregsList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GregsList.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserRepository _db;
        public AccountController(UserRepository repo)
        {
            _db = repo;
        }

        [HttpPost("register")]
        public async Task<UserReturnModel> Register([FromBody]RegisterUserModel creds)
        {
            return _db.Register(creds);
        }
        [HttpPost("login")]
        public async Task<UserReturnModel> Login([FromBody]LoginUserModel creds)
        {
            return _db.Login(creds);
        }
    }
}