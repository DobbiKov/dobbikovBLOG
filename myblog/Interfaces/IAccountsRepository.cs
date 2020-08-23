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
        Task<IEnumerable<DobbiUser>> GetAsync();
        Task<ActionResult<DobbiUser>> GetAsync(string id);
        Task<ActionResult<DobbiUser>> GetAsync(Guid id);
        Task<ActionResult<DobbiUser>> Create(DobbiUser post);
        Task Update(DobbiUser post);
        Task<ActionResult<DobbiUser>> Delete(Guid id);
        Task Init();
        IActionResult GetToken(string username, string password);

        IActionResult UpdateToken(string _token);
    }
}
