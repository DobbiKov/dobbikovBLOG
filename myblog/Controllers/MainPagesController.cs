using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Interfaces;
using myblog.Models;

namespace myblog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPagesController : ControllerBase
    {
        private readonly IMainPageRepository repos;
        public MainPagesController(IMainPageRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public async Task<IEnumerable<MainPage>> Get()
        {
            return await repos.GetAsync();
        }

        [HttpPost("/api/MainPages/Update")]
        public async Task<ActionResult<MainPage>> Update([FromBody] MainPage mainPage)
        {
            return await repos.Update(mainPage) ?? BadRequest(new { errorText = "Беда, пиздец"});
        }
    }
}
