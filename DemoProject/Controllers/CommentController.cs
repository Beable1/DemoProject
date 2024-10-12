using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var comment = await commentService.GetByIdAsync(id);
            commentService.Remove(comment);
            return RedirectToAction("dashboard", "writer");
        }
    }
}
