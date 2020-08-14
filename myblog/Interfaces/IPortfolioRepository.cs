using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> Get();
        Portfolio Get(Guid id);
        void Create(Portfolio post);
        void Update(Portfolio post);
        Portfolio Delete(Guid id);
        void Init();
    }
}
