using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class BlogSlider:ViewComponent
    {
        private readonly IBlogService blogService;

        public BlogSlider(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await blogService.GetBlogsWithCategory();

            return View(blogs);
        }

    }
}
