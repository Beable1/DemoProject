using BusinessLayer.Abstract;
using DemoProject.Models;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList.Extensions;

namespace DemoProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService blogService;
        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var blogs=await blogService.GetBlogsWithCategory();
            var values = blogs.ToPagedList(page, 4);
            return View(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
