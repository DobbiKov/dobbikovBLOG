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
    public class EFProtfolioRepository : IPortfolioRepository
    {
        private ApplicationDbContext db;
        public EFProtfolioRepository(ApplicationDbContext _context)
        {
            this.db = _context;
        }
        public void Create(Portfolio post)
        {
            throw new NotImplementedException();
        }

        public Portfolio Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Portfolio>> GetAsync()
        {
            Init();
            return await db.Portfolios.ToArrayAsync();
        }

        public async Task<ActionResult<Portfolio>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Init()
        {
            if(!db.Portfolios.Any())
            {
                await db.Portfolios.AddRangeAsync
                (
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Image = "huy" },
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" },
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" }
                );
                await db.SaveChangesAsync();
            }
        }

        public void Update(Portfolio post)
        {
            throw new NotImplementedException();
        }
    }
}
