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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }

        public  List<Comment> GetCommentsByBlogIds(List<int> blogIds)
        {
            var comments =  _context.Comments
          .Where(c => blogIds.Contains(c.BlogId))
          .OrderByDescending(c => c.CreatedTime)
          .ToList();

            return comments;
        }
    }
}
