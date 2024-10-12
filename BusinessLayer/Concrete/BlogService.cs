using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogService : Service<Blog>, IBlogService
    {
        IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogService(IGenericRepository<Blog> repository, IUnitOfWork unitOfWork, IBlogRepository blogRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogDetailsDto> GetBlogByIdWithCommentsAsync(int id)
        {
            var blog = await _blogRepository.GetBlogByIdWithCommentsAsync(id);

            return _mapper.Map<BlogDetailsDto>(blog);
        }

        public async Task<List<Blog>> GetBlogsWithCategory()
        {
            return await _blogRepository.GetBlogsWithCategory();
        }
    }
}
