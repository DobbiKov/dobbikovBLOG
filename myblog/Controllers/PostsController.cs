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
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository repos;
        public PostsController(IPostRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await repos.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(Guid id)
        {
            return await repos.GetAsync(id) ?? NotFound();
        }
    }
}
