using BusinessLayer.Abstract;
using DemoProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        private readonly IWriterService writerService;
        

        public WriterController(IWriterService writerService)
        {
            this.writerService = writerService;
            
        }

        public async Task<IActionResult> Index()
        {


            var writers = await writerService.GetAllAsync();
            return View(writers);

        }




    }
}
