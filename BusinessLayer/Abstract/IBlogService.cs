using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IService<Blog>
    {
        Task<BlogDetailsDto> GetBlogByIdWithCommentsAsync(int id);

        Task<List<Blog>> GetBlogsWithCategory();


    }
}
