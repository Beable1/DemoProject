using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class BlogSideContent:ViewComponent
    {
        private readonly IBlogRaytingService raytingService;
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public BlogSideContent(IBlogRaytingService rayingService, IBlogService blogService, ICategoryService categoryService)
        {
            this.raytingService = rayingService;
            this.blogService = blogService;
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogRaytings = await raytingService.GetAllAsync();

            var top4BlogRaytings = blogRaytings.Where(br => br.BlogRaytingCount >= 1).OrderByDescending(br => (br.BlogTotalScore / br.BlogRaytingCount)).Take(4).ToList();

            var blogIds = top4BlogRaytings.Select(br => br.BlogID).ToList();
            var blogs = await blogService.GetBlogsWithCategory();
            var topBlogs = blogs.Where(b => blogIds.Contains(b.Id)).ToList();

            var Categories = await categoryService.GetCategoriesWithBlogsAsync();
            
            ViewBag.Categories = Categories;
            return View(topBlogs);
        }
    }
}
