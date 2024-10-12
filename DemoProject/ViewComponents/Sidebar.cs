using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class Sidebar:ViewComponent
    {
        IWriterService _writerService;
        ICategoryService _categoryService;
        IMapper _mapper;
        public Sidebar(IWriterService writerService, IMapper mapper, ICategoryService categoryService)
        {
            _writerService = writerService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blogs=await _writerService.GetBlogsByWriterId(id);
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = categoriesDto;

           
            return View(blogs);
        }
    }
}
