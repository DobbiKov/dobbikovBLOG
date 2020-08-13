using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFContactsRepository : IContactsRepository
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

        public IEnumerable<Contacts> Get()
        {
            return db.Contacts.ToArray();
        }

        public Contacts Get(Guid id)
        {
            throw new NotImplementedException();
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
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" },
                    new Contacts() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" }
                    );
                db.SaveChanges();
            }
        }
    }
}
