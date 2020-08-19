using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myblog.Interfaces;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsRepository repos;
        public AccountsController(IAccountsRepository _repos)
        {
            repos = _repos;
        }
        [HttpGet]
        public async Task<IEnumerable<DobbiUser>> Get()
        {
            return await repos.GetAsync();
        }

        [HttpPost("/api/Accounts/token")]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            var res = repos.GetToken(model.username, model.password);

            return res ?? BadRequest(new { errorText = $"Неправильный логин, либо пароль. username: {model.username}" });
        }
    }
}
