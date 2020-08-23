using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFPostCommentsRepository : IPostCommentsRepository
    {
        private readonly ApplicationDbContext db;
        public EFPostCommentsRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Create(PostComments post)
        {
            var user = await db.users.FirstOrDefaultAsync(x => x.Token == post.Token);
            post.UserId = user.Id;
            await db.postComments.AddAsync(post);
            await db.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<PostComments>> GetCommentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PostComments> GetCommentsAsync(Guid postid)
        {
            var comments = db.postComments.Where(x => x.PostId == postid);
            return comments;
        }

        public Task Init()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<PostComments>> Update(PostComments post)
        {
            throw new NotImplementedException();
        }
    }
}
