using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Models
{
    public class DobbiUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DobbiRoles Role { get; set; }
        public string TestRole { get; set; }
        public Guid UserRoleId { get; set; }
    }
}
