using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    
    public class ContactController : Controller
    {
        IContactService contactService;
        IMapper mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactDto contactDto)
        {
            
            Console.WriteLine(contactDto.ContactSubject);
            var contact = mapper.Map<Contact>(contactDto);
            await contactService.AddAsync(contact);

            return View();
        }
    }
}
