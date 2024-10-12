using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetBlogByIdWithCommentsAsync(int id);

        Task<List<Blog>> GetBlogsWithCategory();

    }
}
