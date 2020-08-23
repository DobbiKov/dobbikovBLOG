using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IPostCommentsRepository
    {
        IQueryable<PostComments> GetCommentsAsync(Guid postid);
        Task<ActionResult<PostComments>> GetCommentAsync(Guid id);
        Task Create(PostComments post);
        Task<ActionResult<PostComments>> Update(PostComments post);
        Task Delete(Guid id);
        Task Init();
    }
}
