using CoreLayer.DTOs;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoriesWithBlogsAsync()
        {
            return await _context.Categories.Include(c => c.Blogs).ToListAsync();
        }

        public async Task<Category> GetSingleCategoryByIdWithBlogsAsync(int categoryId)
        {

            return await _context.Categories.Include(x => x.Blogs).Where(x => x.Id == categoryId).SingleOrDefaultAsync();

        }
    }
}
