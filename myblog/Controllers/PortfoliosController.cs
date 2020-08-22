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
    [ApiController]
    [Route("api/[controller]")]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioRepository repos;

        public PortfoliosController(IPortfolioRepository _repos)
        {
            repos = _repos;
        }

        // GET: api/Portfolios
        [HttpGet]
        public async Task<IEnumerable<Portfolio>> Get()
        {
            return await repos.GetAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> Get(Guid id)
        {
            return await repos.GetAsync(id) ?? NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Portfolio>> Delete(Guid id)
        {
            return await repos.Delete(id) ?? NotFound();
        }

        [HttpPost("/api/Portfolios/Update")]
        public async Task<ActionResult<Portfolio>> Update([FromBody] Portfolio obj)
        {
            return await repos.Update(obj);
        }

        [HttpPost("/api/Portfolios/Create")]
        public async Task Create([FromBody] Portfolio obj)
        {
            await repos.Create(obj);
        }
    }
}
