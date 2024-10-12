using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public interface IWriterRepository:IGenericRepository<Writer>
    {
        Task<List<Blog>> GetBlogsByWriterId(int id);
        Task<Writer> GetCurrentUserByUserMail(string mail);

        //Task<Writer> GetUserByUserMail(string mail);



    }
}
