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
    public class RolesController : Controller
    {
        private readonly IRolesRepository repos;

        public RolesController(IRolesRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DobbiRoles>> Get(Guid id)
        {
            return await repos.GetAsync(id) ?? NotFound();
        }
    }
}
