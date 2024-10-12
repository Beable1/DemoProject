using CoreLayer.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogDto:BaseDto
    {
        public string BlogTitle { get; set; }

        public string? BlogThumbnailImage { get; set; }

        public string? BlogImage { get; set; }

        public string BlogContent { get; set; }
        
   
        public int CategoryId { get; set; }

        public int WriterID { get; set; }

    }
}
