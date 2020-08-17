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
    public class EFPostRepository : IPostRepository
    {
        private ApplicationDbContext db;
        public EFPostRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAsync()
        {
            Init();
            return await db.posts.ToArrayAsync();
        }

        public async Task<ActionResult<Post>> GetAsync(Guid id)
        {
            var post = await db.posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task Init()
        {
            if (!db.posts.Any())
            {
                await db.posts.AddRangeAsync
                (
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" }
                );
                await db.SaveChangesAsync();
            }
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
