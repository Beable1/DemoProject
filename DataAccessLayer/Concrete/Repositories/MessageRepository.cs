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
    public class MessageRepository : GenericRepository<Message2>, IMessageRepository
    {
        public MessageRepository(Context context) : base(context)
        {
        }

        

        public Message2 GetMessagesById(int id)
        {
            return _context.Message2s.Include(y => y.SenderUser).FirstOrDefault(x => x.MessageID == id);
        }

        public async Task<List<Message2>> GetMessagesByReceiverIdAsync(int id)
        {
           return await _context.Message2s.Include(y=>y.SenderUser).Where(x => x.ReceiverID == id).ToListAsync();
        }

        public async Task<List<Message2>> GetMessagesBySenderIdAsync(int id)
        {
            return await _context.Message2s.Include(y => y.ReceiverUser).Where(x => x.SenderID == id).ToListAsync();
        }
    }
}
