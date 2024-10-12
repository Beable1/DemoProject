using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class NotificationList:BaseComponent
    {
        INotificationService notificationService;
        IMessageService messageService;

        public NotificationList(INotificationService notificationService, IMessageService messageService)
        {
            this.notificationService = notificationService;
            this.messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             var CurrentUser= GetCurrentUser();
            var notifications = await messageService.GetMessagesByReceiverIdAsync(CurrentUser.Id);
            return View(notifications);
        }

    }
}
