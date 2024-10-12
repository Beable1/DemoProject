using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class WriterRepository : GenericRepository<Writer>, IWriterRepository
    {
        public WriterRepository(Context context) : base(context)
        {
        }

        public async Task<List<Blog>> GetBlogsByWriterId(int id)
        {
            return await _context.Blogs.Where(x=>x.WriterID == id).ToListAsync();
        }

        public async Task<Writer> GetCurrentUserByUserMail(string mail)
        {

            var existingWriter = await _context.Writers.Where(x => x.WriterMail == mail).FirstOrDefaultAsync();
            if (existingWriter != null)
            {
                _context.Entry(existingWriter).State = EntityState.Detached;
            }
            return existingWriter;

        }

        //public async Task<Writer> GetUserByUserMail(string mail)
        //{

        //    var Writer = await _context.Writers.Where(x => x.WriterMail == mail).FirstOrDefaultAsync();

        //    return Writer;

        //}
    }
}
