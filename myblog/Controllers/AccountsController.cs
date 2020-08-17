using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myblog.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsRepository repos;
        public AccountsController(IAccountsRepository _repos)
        {
            repos = _repos;
        }

        [HttpPost("/api/Accounts/token")]
        public IActionResult GetToken(string username, string password)
        {
            var res = repos.GetToken(username, password);

            return res ?? BadRequest(new { errorText = "Invalid username or password." });
        }
    }
}
