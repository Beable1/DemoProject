using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        ICategoryRepository _repository;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _repository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesWithBlogsAsync()
        {
           return await _repository.GetCategoriesWithBlogsAsync();
        }

        public async Task<Category> GetSingleCategoryByIdWithBlogsAsync(int categoryId)
        {
            return await _repository.GetSingleCategoryByIdWithBlogsAsync(categoryId);
        }
    }
}
