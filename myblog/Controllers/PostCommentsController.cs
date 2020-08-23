using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myblog.Interfaces;
using myblog.Models;

namespace myblog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostCommentsController : ControllerBase
    {
        private readonly IPostCommentsRepository repos;
        public PostCommentsController(IPostCommentsRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{id}")]
        public IQueryable<PostComments> Get(Guid id)
        {
            return repos.GetCommentsAsync(id);
        }

        [HttpPost("/api/PostComments/NewComment")]
        public async Task Create([FromBody] PostComments obj)
        {
            await repos.Create(obj);
        }
    }
}
