using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> Get();
        Post Get(Guid id);
        void Create(Post post);
        void Update(Post post);
        Post Delete(Guid id);
        void Init();
    }
}
