using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFContactsRepository : IContactRepository
    {
        private readonly ApplicationDbContext db;
        public EFContactsRepository(ApplicationDbContext _context)
        {
            this.db = _context;
        }
        public async Task Create(Contacts post)
        {
            await db.Contacts.AddAsync(post);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var obj = await db.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null) db.Contacts.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAsync()
        {
            await Init();
            return await db.Contacts.ToArrayAsync();
        }

        public async Task<ActionResult<Contacts>> GetAsync(Guid id)
        {
            return await db.Contacts.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<ActionResult<Contacts>> Update(Contacts post)
        {
            db.Entry(post).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return post;
        }
        public async Task Init()
        {
            if (!db.Contacts.Any())
            {
                await db.Contacts.AddRangeAsync
                    (
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://youtube.com/DOBBICRMP", Title = "YouTube CHannel DOBBI CRMP", Name = "My youtube channel", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://vk.com/dobbikov", Title = "my blog in VK", Name = "My VK Blog", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://instagram.com/dobbikov", Title = "My Intsagram account", Name = "My Instagram", Image = "huy" }
                    );
                await db.SaveChangesAsync();
            }
        }
    }
}
