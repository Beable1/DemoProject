using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        private readonly IBlogService _blogService;

        public CommentList(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var comments = await _blogService.GetBlogByIdWithCommentsAsync(blogId);
            
            return View(comments.Comments);
        }



    }
}
