using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        public NotificationService(IGenericRepository<Notification> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
