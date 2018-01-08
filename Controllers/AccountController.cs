using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            if (ModelState.IsValid)
            {
                UserReturnModel user = db.Register(creds);
                if(user != null)
                {
                    var claims = new List<Claim> {}
                }
                return _db.Register(creds);
            }
            else
            {
                return null;
            }
        }
        [HttpPost("login")]
        public async Task<UserReturnModel> Login([FromBody]LoginUserModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = db.Login(creds);
                if (user != null)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };
                    {
                new Claim(ClaimTypes.Email, user.Email)
            };
                    return _db.Login(creds);
                }
                return null;
            }
        }
    }
}
