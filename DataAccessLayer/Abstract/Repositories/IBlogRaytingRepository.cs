using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public interface IBlogRaytingRepository:IGenericRepository<BlogRayting>
    {

        Task<BlogRayting> GetBlogRaytingByBlogId(int  blogId);

        Task<List<BlogRayting>> GetBlogRaytingsByWriterId(int writerId);

        Task<float> GetTotalRayting(); 
    }
}
