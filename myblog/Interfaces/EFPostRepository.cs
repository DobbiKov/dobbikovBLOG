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

        public IEnumerable<Post> Get()
        {
            Init();
            return db.posts.ToArray();
        }

        public Post Get(Guid id)
        {
            var post = db.posts.FirstOrDefault(x => x.Id == id);
            return post;
        }

        public void Init()
        {
            if (!db.posts.Any())
            {
                db.posts.AddRange
                (
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" }
                );
                db.SaveChanges();
            }
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
