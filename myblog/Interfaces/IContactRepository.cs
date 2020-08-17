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
        void Create(Contacts post);
        void Update(Contacts post);
        Contacts Delete(Guid id);
        void Init();
    }
}