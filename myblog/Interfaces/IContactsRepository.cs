using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public interface IContactsRepository
    {
        IEnumerable<Contacts> Get();
        Contacts Get(Guid id);
        void Create(Contacts post);
        void Update(Contacts post);
        Contacts Delete(Guid id);
        void Init();
    }
}
