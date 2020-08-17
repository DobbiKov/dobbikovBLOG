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
    }
}
