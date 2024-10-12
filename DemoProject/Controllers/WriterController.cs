using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.DTOs;
using DemoProject.Utilities;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Controllers
{
    public class WriterController : BaseController
    {
        private readonly IWriterService writerService;
        private readonly IBlogService blogService;
        private readonly IMapper mapper;
        private readonly IMessageService messageService;
        private readonly IBlogRaytingService blogRaytingService;
        private readonly ICategoryService _categoryService;

        public WriterController(IBlogService blogService, IMapper mapper, IWriterService writerService, ICategoryService categoryService, IBlogRaytingService blogRaytingService, IMessageService messageService)
        {
            this.blogService = blogService;
            this.mapper = mapper;
            this.writerService = writerService;
            _categoryService = categoryService;
            this.blogRaytingService = blogRaytingService;
            this.messageService = messageService;
        }


        public async Task<IActionResult> Blogs()
        {
            

            var blogs=await writerService.GetBlogsByWriterId(CurrentUser.Id);
            ViewBag.Id = CurrentUser.Id;
            
            return View(blogs);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");
            ViewBag.id = CurrentUser.Id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDto blogDto)
        {

            var Id = Request.Form["id"];
            var blogTitle = Request.Form["BlogTitle"];
            var blogContent = Request.Form["BlogContent"];
            var categoryId = Request.Form["CategoryId"];
            var blogThumbnail = Request.Form.Files["BlogThumbnail"];
            var nameImage = "";


           
           

            if(ModelState.IsValid) {


                if (blogThumbnail != null)
                {
                    var extension = Path.GetExtension(blogThumbnail.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogThumbnails/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    blogThumbnail.CopyTo(stream);
                    nameImage = newimagename;

                }

                var blog = new BlogDto
                {
                    WriterID = int.Parse(Id),
                    CategoryId = int.Parse(categoryId),
                    BlogContent = blogContent,
                    BlogTitle = blogTitle,
                    BlogThumbnailImage=nameImage

                };

                await blogService.AddAsync(mapper.Map<Blog>(blog));
            return RedirectToAction("blogs","writer", new { id = Id });
            }

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");

            return View(blogDto);

        }



        public async Task<IActionResult> Update(int id)
        {
            var blog=await blogService.GetByIdAsync(id);
            var blogDto=mapper.Map<BlogDto>(blog);

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");
            ViewBag.id=blog.WriterID;


           

            return View(blogDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogDto blogDto)
        {
            
            var WriterId = Request.Form["WriterId"];
            var blogTitle = Request.Form["BlogTitle"];
            var blogContent = Request.Form["BlogContent"];
            var categoryId = Request.Form["CategoryId"];
            var blogThumbnail = Request.Form.Files["BlogThumbnail"];


            if (ModelState.IsValid)
            {
                var blog = await blogService.GetByIdAsync(blogDto.Id);

                if (blogThumbnail != null)
                {
                    var folderPath = "wwwroot/BlogThumbnails/";
                    var nameImage = ImageHelper.SaveImage(blogThumbnail, folderPath);
                    blog.BlogThumbnailImage = nameImage;
                }

                blog.WriterID = int.Parse(WriterId);
                blog.CategoryId = int.Parse(categoryId);
                blog.BlogContent = blogContent;
                blog.BlogTitle = blogTitle;

                blogService.Update(blog);

                return RedirectToAction("blogs", "writer", new { id = blog.WriterID });
            }

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");

            return View(blogDto);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var blog = await blogService.GetByIdAsync(id);
             blogService.Remove(blog);
            return RedirectToAction("blogs", "writer", new { id = blog.WriterID });
        }

        public async Task<IActionResult> Dashboard()
        {
            var comments= await writerService.GetLastCommentsByWriterId(CurrentUser.Id);
            var blogs = await blogService.GetAllAsync();
            var blogsDto=mapper.Map<List<BlogDto>>(blogs.ToList());
            var blogsDictionary = blogsDto.ToDictionary(c => c.Id, c => c.BlogTitle);
            ViewBag.blogsDictionary=blogsDictionary;
            ViewBag.WriterId = CurrentUser.Id;
            return View(comments);
        }

        

    }
}
