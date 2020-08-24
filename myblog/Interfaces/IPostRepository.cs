using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAsync();
        Task<ActionResult<Post>> GetAsync(Guid id);
        Task<ActionResult<Post>> Create(Post post);
        Task<ActionResult<Post>> Update(Post post);
        Task Delete(Guid id);
        Task Init();

        Task UploadPhoto(Guid id, IFormFile file);
    }
}
