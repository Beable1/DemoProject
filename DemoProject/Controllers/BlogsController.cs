using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.DTOs;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace DemoProject.Controllers
{
    [AllowAnonymous]
    public class BlogsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public BlogsController(IBlogService blogService, IMapper mapper, ICategoryService categoryService, ICommentService commentService, IWriterService writerService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _categoryService = categoryService;
            _commentService = commentService;
            _writerService = writerService;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            var writers = await _writerService.GetAllAsync();
            var writersDto= _mapper.Map<List<WriterDto>>(writers.ToList());

            var categoryDictionary = categoriesDto.ToDictionary(c => c.Id, c => c.CategoryName);
            var categoryDateDictionary = categoriesDto.ToDictionary(c => c.Id, c => c.CreatedTime);
            var writerDictionary=writersDto.ToDictionary(c => c.Id, c=> c.WriterName);

            ViewBag.CategoryDictionary = categoryDictionary;
            ViewBag.WriterDictionary = writerDictionary;
            

            var blogs = await _blogService.GetAllAsync();
            var blogsDto=  _mapper.Map<List<BlogDto>>(blogs);

            var values = blogsDto.ToPagedList(page, 4);
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDto blogDto)
        {


            await _blogService.AddAsync(_mapper.Map<Blog>(blogDto));
            return RedirectToAction(nameof(Index));

            

        }

        [HttpGet]
        public async Task<IActionResult> BlogDetails(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            
            
            ViewBag.categories = categoriesDto;

            var blog = await _blogService.GetBlogByIdWithCommentsAsync(id);

            var writer=await _writerService.GetByIdAsync(blog.WriterId);
            var writerDto=_mapper.Map<WriterDto>(writer);
            ViewBag.writer=writerDto;
            
            ViewBag.blogCategory = blog.Category.CategoryName;
            
            
            
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> BlogDetails()
        {
            var blogId = Request.Form["BlogId"];
            var commentUserName = Request.Form["CommentUserName"];
            var commentTitle = Request.Form["CommentTitle"];
            var commentContent = Request.Form["CommentContent"];
            var rating = Request.Form["Rating"];

            var comment = new CommentDto
            {
                BlogScore=int.Parse(rating),
                BlogId = int.Parse(blogId),
                CommentUserName = commentUserName,
                CommentTitle = commentTitle,
                CommentContent = commentContent
            };

            var commentNoDto=_mapper.Map<Comment>(comment);
            await _commentService.AddAsync(commentNoDto);

            return RedirectToAction("BlogDetails", new { id = blogId });

        }

        
    }
}
