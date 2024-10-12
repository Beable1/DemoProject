using AutoMapper;
using BusinessLayer.Abstract;
using CoreLayer.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesWithBlogsAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int i)
        {
            
            var categoryName = Request.Form["CategoryName"];
            var categoryDescription = Request.Form["CategoryDescription"];

            var category = new Category
            {
                CategoryName = categoryName,
                CategoryDescription = categoryDescription,
                CategoryStatus = true
            };

            await _categoryService.AddAsync(category);
            return View();
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {


            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction(nameof(Index));



        }

        public async Task<IActionResult> Update(int id)
        {
            var category=await _categoryService.GetByIdAsync(id);

            return View(category);

        }

        [HttpPost]  
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);

            return RedirectToAction("index","category");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var category=await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(category);

            return RedirectToAction("Index", "Category");
        }
    }
}
