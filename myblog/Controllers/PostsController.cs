using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("/api/Posts/Create")]
        public async Task<ActionResult<Post>> Create(Post post)
        {
            return await repos.Create(post);
        }        
        [HttpPost("/api/Posts/UploadPhoto/{id}")]
        public async Task UploadPhoto(IFormFile file, Guid id)
        {
            await repos.UploadPhoto(id, file);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await repos.Delete(id);
        }
        [HttpPost("/api/Posts/Update")]
        public async Task<ActionResult<Post>> Update([FromBody] Post post)
        {
            return await repos.Update(post);
        }
    }
}
