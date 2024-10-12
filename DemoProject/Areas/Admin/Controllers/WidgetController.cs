using BusinessLayer.Abstract;
using DemoProject.Areas.Admin.Services;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WidgetController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IWriterService writerService;
        private readonly ICommentService commentService;
        private readonly IBlogRaytingService blogRaytingService;
        private readonly ICategoryService categoryService;
        
		public WidgetController(CategoryApiService categoryApiService, IBlogService blogService, IWriterService writerService, ICommentService commentService, IBlogRaytingService blogRaytingService, ICategoryService categoryService)
		{
			this.commentService = commentService;
			this.blogService = blogService;
			this.writerService = writerService;
			this.blogRaytingService = blogRaytingService;

			
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
        {
            var writers=await writerService.GetAllAsync();
            var blogs = await blogService.GetAllAsync();
            var commets= await commentService.GetAllAsync();
            var categories= await categoryService.GetCategoriesWithBlogsAsync();

			ViewBag.WriterCount =writers.Count();
            ViewBag.BlogCount=blogs.Count();
            ViewBag.CommentCount=commets.Count();   
            ViewBag.TotalRating=await blogRaytingService.GetTotalRating();

			var categoryStatistics = categories.Select(c => new
			{
				CategoryName = c.CategoryName,
				BlogCount = c.Blogs.Count
			}).ToList();


			
            ViewBag.CategoryData = categoryStatistics;

          
            
            return View();
        }
    }
}
