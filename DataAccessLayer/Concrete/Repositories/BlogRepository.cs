using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(Context context) : base(context)
        {
        }

        public async Task<Blog> GetBlogByIdWithCommentsAsync(int id)
        {
            return await _context.Blogs.Include(x => x.Category).Include(x => x.Comments).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Blog>> GetBlogsWithCategory()
        {
            return await _context.Blogs.Include(x => x.Category).Include(x => x.Comments).Include(x => x.Writer).ToListAsync();
        }
    }
}
    