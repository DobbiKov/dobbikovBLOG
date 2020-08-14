using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Model> Get();
        Model Get(Guid id);
        void Create(Model post);
        void Update(Model post);
        Model Delete(Guid id);
        void Init();
    }
}
