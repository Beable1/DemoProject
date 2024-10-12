using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public interface IMessageRepository:IGenericRepository<Message2>
    {
        Task<List<Message2>> GetMessagesByReceiverIdAsync(int id);


        Task<List<Message2>> GetMessagesBySenderIdAsync(int id);

        Message2 GetMessagesById(int id);
    }
}
