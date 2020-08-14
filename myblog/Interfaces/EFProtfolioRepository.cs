using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFProtfolioRepository : IRepository
    {
        private ApplicationDbContext db;
        public EFProtfolioRepository(ApplicationDbContext _context)
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
            return db.Portfolio.ToArray();
        }

        public Model Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            if(!db.Portfolio.Any())
            {
                db.Portfolio.AddRange
                                    (
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Image = "huy" },
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" },
                    new Portfolio() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Image = "huy" }
                    );
            }
        }

        public void Update(Model post)
        {
            throw new NotImplementedException();
        }
    }
}
