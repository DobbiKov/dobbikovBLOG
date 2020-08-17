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
        private ApplicationDbContext db;
        public EFContactsRepository(ApplicationDbContext _context)
        {
            this.db = _context;
        }
        public void Create(Contacts post)
        {
            throw new NotImplementedException();
        }

        public Contacts Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contacts>> GetAsync()
        {
            Init();
            return await db.Contacts.ToArrayAsync();
        }

        public async Task<ActionResult<Contacts>> GetAsync(Guid id)
        {
            var contact = db.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            return await contact;
        }

        public void Update(Contacts post)
        {
            throw new NotImplementedException();
        }
        public void Init()
        {
            if (!db.Contacts.Any())
            {
                db.Contacts.AddRange
                    (
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://youtube.com/DOBBICRMP", Title = "YouTube CHannel DOBBI CRMP", Name = "My youtube channel", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://vk.com/dobbikov", Title = "my blog in VK", Name = "My VK Blog", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://instagram.com/dobbikov", Title = "My Intsagram account", Name = "My Instagram", Image = "huy" }
                    );
                db.SaveChanges();
            }
        }
    }
}
