using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogRaytingService:IService<BlogRayting>
    {
        Task<BlogRayting> GetBlogRaytingByBlogId(int blogId);
        Task<List<BlogRayting>> GetBlogRaytingsByWriterId(int writerId);
        Task<float> GetTotalRating();
    }
}
