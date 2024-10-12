using CoreLayer.DTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogDetailsDto:BlogDto
    {

        public List<Comment> Comments { get; set; }

        public Category Category { get; set; }
        public string? BlogThumbnailImage { get; set; }

        public int WriterId { get; set; }

    }
}
