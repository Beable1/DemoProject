using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService:IService<Category>
    {
        public Task<Category> GetSingleCategoryByIdWithBlogsAsync(int categoryId);
        Task<List<Category>> GetCategoriesWithBlogsAsync();
    }
}
