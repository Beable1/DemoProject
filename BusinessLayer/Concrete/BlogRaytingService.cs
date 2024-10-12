using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogRaytingService : Service<BlogRayting>, IBlogRaytingService
    {
        private readonly IBlogRaytingRepository raytingRepository;
        public BlogRaytingService(IGenericRepository<BlogRayting> repository, IUnitOfWork unitOfWork, IBlogRaytingRepository raytingRepository) : base(repository, unitOfWork)
        {
            this.raytingRepository=raytingRepository;
        }

        public async Task<BlogRayting> GetBlogRaytingByBlogId(int blogId)
        {
           var blogRayting  = await raytingRepository.GetBlogRaytingByBlogId(blogId);
            return blogRayting;
        }

        public async Task<List<BlogRayting>> GetBlogRaytingsByWriterId(int writerId)
        {
            return await raytingRepository.GetBlogRaytingsByWriterId(writerId);
        }

        public async Task<float> GetTotalRating()
        {
            return await raytingRepository.GetTotalRayting();
        }
    }
}
