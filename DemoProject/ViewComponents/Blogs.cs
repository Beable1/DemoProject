using BusinessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class Blogs:ViewComponent
    {
        private readonly IBlogRaytingService blogRaytingService;

        public Blogs(IBlogRaytingService blogRaytingService)
        {
            this.blogRaytingService = blogRaytingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var blogRayting=await blogRaytingService.GetBlogRaytingByBlogId(blogId);

            return View(blogRayting);
        }
    }
}
