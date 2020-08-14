using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Models
{
    public abstract class Model
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Image { get; set; }
        public virtual string Link { get; set; }
    }
}
