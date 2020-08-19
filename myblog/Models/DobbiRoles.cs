using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Models
{
    public class DobbiRoles
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanBanUsers { get; set; }
        public bool CanCreateRoles { get; set; }
        public bool CanEditMainPage { get; set; }
    }
}
