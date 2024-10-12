using DataAccessLayer.Abstract.Repositories;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService:IService<Writer>
    {
        Task<List<BlogDto>> GetBlogsByWriterId(int id);

        Task<List<CommentDto>> GetLastCommentsByWriterId(int id);

        Task<Writer> GetCurrentUserByUsername(string username);

        //Task<Writer> GetUserByUserMail(string mail);
    }
}
