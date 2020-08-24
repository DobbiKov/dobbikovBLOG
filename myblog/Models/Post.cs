using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Models
{
    public class Post : Model
    {
        public override Guid Id { get; set; }
        public override string Name { get; set; }
        public override string Title { get; set; }
        public string Text { get; set; }
        public override string Image { get; set; }
        public override string Link { get; set; }

        [NotMapped]
        public IFormFile photo { get; set; }
    }
}
