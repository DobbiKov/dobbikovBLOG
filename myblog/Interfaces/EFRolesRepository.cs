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
    public class EFRolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext db;
        public EFRolesRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public Task Create(DobbiRoles post)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<DobbiRoles>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DobbiRoles>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<DobbiRoles>> GetAsync(Guid id)
        {
            var result = await db.roles.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task Init()
        {
            if (!db.roles.Any())
            {
                await db.roles.AddRangeAsync(
                    new DobbiRoles() { Name = "SystemAdmin", CanBanUsers = true, CanCreate = true, CanCreateRoles = true, CanDelete = true, CanEdit = true, CanEditMainPage = true, Id = new Guid("00000000-0000-0000-0000-000000000006") },
                    new DobbiRoles() { Name = "User", CanBanUsers = false, CanCreate = false, CanCreateRoles = false, CanDelete = false, CanEdit = false, CanEditMainPage = false, Id = new Guid("00000000-0000-0000-0000-000000000002") },
                    new DobbiRoles() { Name = "Redactor", CanBanUsers = false, CanCreate = true, CanCreateRoles = false, CanDelete = false, CanEdit = false, CanEditMainPage = false, Id = new Guid("00000000-0000-0000-0000-000000000003") },
                    new DobbiRoles() { Name = "Admin", CanBanUsers = true, CanCreate = true, CanCreateRoles = false, CanDelete = true, CanEdit = true, CanEditMainPage = false, Id = new Guid("00000000-0000-0000-0000-000000000004") },
                    new DobbiRoles() { Name = "Banned", CanBanUsers = false, CanCreate = false, CanCreateRoles = false, CanDelete = false, CanEdit = false, CanEditMainPage = false, Id = new Guid("00000000-0000-0000-0000-000000000005") }
                );
                await db.SaveChangesAsync();
            }
        }

        public Task Update(DobbiRoles post)
        {
            throw new NotImplementedException();
        }
    }
}
