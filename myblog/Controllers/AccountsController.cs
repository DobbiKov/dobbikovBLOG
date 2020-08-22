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

        [HttpGet("{id}")]
        public async Task<ActionResult<DobbiUser>> Get(string id)
        {
            return await repos.GetAsync(id) ?? NotFound();
        }

        [HttpPost("/api/Accounts/token")]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            var res = repos.GetToken(model.username, model.password);

            return res ?? BadRequest(new { errorText = $"Неправильный логин, либо пароль. username: {model.username}" });
        }

        [HttpPost("/api/Accounts/updateToken")]
        public IActionResult UpdateToken([FromBody] UpdateTokenModel tm)
        {
            var res = repos.UpdateToken(tm.token);
            return res ?? BadRequest(new { errorText = $"Токены не свопадают: {tm.token}" });
        }

        [HttpPost("/api/Accounts/Register")]
        public async Task<ActionResult<DobbiUser>> CreateAccount(DobbiUser user)
        {
            return await repos.Create(user) ?? BadRequest(new { errorText = "Пользователь с таким логином уже есть."});
        }
    }
}
