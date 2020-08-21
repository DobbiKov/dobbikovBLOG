using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IMainPageRepository
    {
        Task<ActionResult<MainPage>> Update(MainPage mainPage);
        Task<IEnumerable<MainPage>> GetAsync();
    }
}
