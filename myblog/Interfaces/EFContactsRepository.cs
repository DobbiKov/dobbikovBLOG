using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFContactsRepository : IRepository
    {
        private ApplicationDbContext db;
        public EFContactsRepository(ApplicationDbContext _context)
        {
            this.db = _context;
        }
        public void Create(Model post)
        {
            throw new NotImplementedException();
        }

        public Model Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> Get()
        {
            Init();
            return db.Contacts.ToArray();
        }

        public Model Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Model post)
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
