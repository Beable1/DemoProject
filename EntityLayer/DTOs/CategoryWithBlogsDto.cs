using CoreLayer.DTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class CategoryWithBlogsDto:CategoryDto
    {   
        List<Blog> Blogs { get; set; }

    }
}
