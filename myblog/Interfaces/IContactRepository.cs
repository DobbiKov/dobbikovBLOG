using Microsoft.AspNetCore.Mvc;
using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contacts>> GetAsync();
        Task<ActionResult<Contacts>> GetAsync(Guid id);
        Task Create(Contacts post);
        Task<ActionResult<Contacts>> Update(Contacts post);
        Task Delete(Guid id);
        Task Init();
    }
}