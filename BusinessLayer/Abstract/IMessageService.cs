using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IService<Message2>
    {
        Task<List<Message2>> GetMessagesByReceiverIdAsync(int id);
        Message2 GetMessagesById(int id);

        Task<List<Message2>> GetMessagesBySenderIdAsync(int id);
        Task AddMessageAsync(Message2 message);
    }
}
