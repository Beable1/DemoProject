using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class Conversations:BaseComponent
    {
        IMessageService messageService;

        public Conversations(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CurrentUser = GetCurrentUser();

            var messages = await messageService.GetMessagesByReceiverIdAsync(CurrentUser.Id);
            

            return View(messages);
        }
    }
}
