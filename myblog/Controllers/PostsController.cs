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
        public IEnumerable<Post> Get()
        {
            return repos.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return new ObjectResult(repos.Get(id));
        }
    }
}
