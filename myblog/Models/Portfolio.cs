using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Models
{
    public class Portfolio : Model
    {
        public override Guid Id { get; set; }
        public override string Name { get; set; }
        public override string Title { get; set; }
        public override string Image { get; set; }
        public override string Link { get; set; }
        public string Test { get; set; }
    }
}
