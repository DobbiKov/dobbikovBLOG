using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAsync();
        Task<ActionResult<ApplicationUser>> GetAsync(Guid id);
        Task Create(ApplicationUser post);
        Task Update(ApplicationUser post);
        Task<ActionResult<ApplicationUser>> Delete(Guid id);
        Task Init();
        IActionResult GetToken(string username, string password);
    }
}
