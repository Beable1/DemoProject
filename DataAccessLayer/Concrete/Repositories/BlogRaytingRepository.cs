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
    public class BlogRaytingRepository : GenericRepository<BlogRayting>, IBlogRaytingRepository
    {
        public BlogRaytingRepository(Context context) : base(context)
        {
        }

        public async Task<BlogRayting> GetBlogRaytingByBlogId(int blogId)
        {
            return await _context.BlogRaytings.Where(x => x.BlogID == blogId).FirstOrDefaultAsync();
        }



        public async Task<List<BlogRayting>> GetBlogRaytingsByWriterId(int writerId)
        {
            var blogIds = await _context.Blogs.Where(b => b.WriterID == writerId).Select(b => b.Id).ToListAsync();


            return await _context.BlogRaytings.Where(br => blogIds.Contains(br.BlogID)).ToListAsync();
        }

        public async Task<float> GetTotalRayting()
        {
            var totalRayting = await _context.BlogRaytings
                                    .SumAsync(br => br.BlogTotalScore);

            var ratingCount = await _context.BlogRaytings
                                            .CountAsync();


            return ratingCount > 0 ? totalRayting / ratingCount : 0;

        }
    }
}
