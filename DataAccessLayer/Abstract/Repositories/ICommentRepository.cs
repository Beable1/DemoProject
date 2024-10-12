using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        List<Comment> GetCommentsByBlogIds(List<int> blogIds);
    }
}
