using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DemoProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IActionResult> ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID"; //ilk hücre başlığı
                worksheet.Cell(1, 2).Value = "Blog Adı"; //ikinci hücre başlığı

                int BlogRowCount = 2;

                var blogTitleList = await BlogTitleList();
                foreach (var item in blogTitleList)
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id; //2. satırdan başlayacak ve ilk değerini statik olarak oluşturduğumuz veritabanından alacak
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma2.xlsx");
                }
            }
        }


        public async Task<List<BlogModel2>> BlogTitleList()
        {
            

            var blogs=await blogService.GetAllAsync();

            List<BlogModel2> bm = blogs.Select(blog => new BlogModel2
            {
                Id = blog.Id,
                BlogName = blog.BlogTitle
               
            }).ToList();

            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

    }
}
