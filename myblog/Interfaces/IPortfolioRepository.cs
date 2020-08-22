using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetAsync();
        Task<ActionResult<Portfolio>> GetAsync(Guid id);
        Task Create(Portfolio post);
        Task<ActionResult<Portfolio>> Update(Portfolio post);
        Task<ActionResult<Portfolio>> Delete(Guid id);
        Task Init();
    }
}
