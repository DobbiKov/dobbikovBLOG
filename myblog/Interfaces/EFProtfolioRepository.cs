using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFProtfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext db;
        public EFProtfolioRepository(ApplicationDbContext _context)
        {
            this.db = _context;
        }
        public async Task Create(Portfolio post)
        {
            await db.Portfolios.AddAsync(post);
            await db.SaveChangesAsync();
        }

        public async Task<ActionResult<Portfolio>> Delete(Guid id)
        {
            var res = await db.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null) return null;

            db.Portfolios.Remove(res);
            await db.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Portfolio>> GetAsync()
        {
            await Init();
            return await db.Portfolios.ToArrayAsync();
        }

        public async Task<ActionResult<Portfolio>> GetAsync(Guid id)
        {
            return await db.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<ActionResult<Portfolio>> Update(Portfolio post)
        {
            db.Entry(post).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return await db.Portfolios.FirstOrDefaultAsync(x => x.Id == post.Id);
        }
    }
}
