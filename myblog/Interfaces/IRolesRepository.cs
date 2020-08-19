using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<DobbiRoles>> GetAsync();
        Task<ActionResult<DobbiRoles>> GetAsync(Guid id);
        Task Create(DobbiRoles post);
        Task Update(DobbiRoles post);
        Task<ActionResult<DobbiRoles>> Delete(Guid id);
        Task Init();
    }
}
