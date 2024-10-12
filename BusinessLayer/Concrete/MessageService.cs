using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageService : Service<Message2>, IMessageService
    {
        IMessageRepository messageRepository;
        IUnitOfWork unitOfWork;
        
        public MessageService(IGenericRepository<Message2> repository, IUnitOfWork unitOfWork, IMessageRepository messageRepository) : base(repository, unitOfWork)
        {
            this.messageRepository = messageRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddMessageAsync(Message2 message)
        {
            await messageRepository.AddAsync(message);
            await unitOfWork.CommitMessageAsync();
        }

        public Message2 GetMessagesById(int id)
        {
            return messageRepository.GetMessagesById(id);
        }

        public async Task<List<Message2>> GetMessagesByReceiverIdAsync(int id)
        {
            return await messageRepository.GetMessagesByReceiverIdAsync(id);
        }

        public async Task<List<Message2>> GetMessagesBySenderIdAsync(int id)
        {
            return await messageRepository.GetMessagesBySenderIdAsync(id);
        }
    }
}
