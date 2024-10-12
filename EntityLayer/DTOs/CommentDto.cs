using CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class CommentDto:BaseDto
    {
        public string CommentUserName { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public int BlogScore { get; set; }
        public int BlogId { get; set; }

    }
}
