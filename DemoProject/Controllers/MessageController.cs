using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.DTOs;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IWriterService _writerService;
        private readonly IMessageService messageService;
        private readonly IMapper mapper;
        public MessageController(IMessageService messageService, IMapper mapper, IWriterService writerService)
        {
            this.messageService = messageService;
            this.mapper = mapper;
            _writerService = writerService;
        }

        public async Task<IActionResult> Inbox()
        {
            var messages = await messageService.GetMessagesByReceiverIdAsync(CurrentUser.Id);
            var messagesDto = mapper.Map<List<MessageDto>>(messages);
            ViewBag.Outbox=await messageService.GetMessagesBySenderIdAsync(CurrentUser.Id);

            return View(messagesDto);  
        }


        public IActionResult Details(int id)
        {
            var message =  messageService.GetMessagesById(id);
            var messageDto = mapper.Map<MessageDto>(message);
            
            return View(messageDto);
        }

        public async Task<IActionResult> Send()
        {
            var writers = await _writerService.GetAllAsync();
            var filteredWriters = writers.Where(w => w.Id != CurrentUser.Id).ToList();

            ViewBag.writers = new SelectList(filteredWriters, "Id", "WriterName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(Message2 message)
        {
            message.SenderID= CurrentUser.Id;
            

            await messageService.AddMessageAsync(message);

            return RedirectToAction("inbox","message");
        }

    }
}
