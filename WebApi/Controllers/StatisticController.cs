using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public StatisticController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesStatistics()
        {
            var categories=await categoryService.GetCategoriesWithBlogsAsync();

            var categoryStatistics = categories.Select(c => new
            {
                CategoryName = c.CategoryName,
                BlogCount = c.Blogs.Count
            }).ToList();

            return Ok(categoryStatistics);
        }

    }
}
