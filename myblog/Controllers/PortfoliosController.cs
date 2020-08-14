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
    public class PortfoliosController : ControllerBase
    {
        private readonly IRepository repos;

        public PortfoliosController(IRepository _repos)
        {
            this.repos = _repos;
        }

        // GET: api/Portfolios
        [HttpGet]
        public IEnumerable<Model> Get()
        {
            return repos.Get();
        }
    }
}
