using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogWithCommentsDto
    {
        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }
        public int CategoryId { get; set; }

        public List<Comment> Comments { get; set; }

        public int? WriterID { get; set; }
    }
}
