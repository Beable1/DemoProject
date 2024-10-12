using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DemoProject.Utilities;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IBlogService blogService;
        private readonly IWriterService _writerService;
        private readonly IMapper _mapper;

        public ProfileController(IBlogService blogService, IWriterService writerService, IMapper mapper)
        {
            this.blogService = blogService;
            _writerService = writerService;
            _mapper = mapper;
        }

        public IActionResult Details()
        {
  
            var writerDto = _mapper.Map<WriterDto>(CurrentUser);

            return View(writerDto);
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {

            var writerDto = _mapper.Map<WriterDto>(CurrentUser);
            ViewBag.id = writerDto.Id;

            return View(writerDto);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile()
        {
            
            var writerName = Request.Form["WriterName"];
            var writerAbout = Request.Form["WriterAbout"];
            var writerMail = Request.Form["WriterMail"];
            var writerPassword = Request.Form["WriterPassword"];
            var writerImage = Request.Form.Files["WriterImage"];
            

            var folderPath = "wwwroot/BlogThumbnails/";
            var nameImage = ImageHelper.SaveImage(writerImage, folderPath);


            var writerDto = new WriterDto
            {
                Id= CurrentUser.Id,
                WriterName = writerName,
                WriterAbout = writerAbout,
                WriterMail = writerMail,
                WriterPassword = writerPassword,
                WriterImage = nameImage

            };
            
            _writerService.Update(_mapper.Map<Writer>(writerDto));




            return RedirectToAction("details", "profile");
        }


    }
}
