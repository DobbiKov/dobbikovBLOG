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
    public class EFMainPageRepository : IMainPageRepository
    {
        private readonly ApplicationDbContext db;
        public EFMainPageRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<ActionResult<MainPage>> Update(MainPage _mainPage)
        {
            db.Entry(_mainPage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return await db.mainPage.FirstOrDefaultAsync(x => x.Id == _mainPage.Id);
        }

        public async Task<IEnumerable<MainPage>> GetAsync()
        {
            await Init();
            return await db.mainPage.ToArrayAsync();
        }
        private async Task Init()
        {
            if (!db.mainPage.Any())
            {
                await db.mainPage.AddAsync(new MainPage() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Title = "DobbiKov", Text = "Lorem Ipsum" });
                await db.SaveChangesAsync();
            }
        }
    }
}
