using BusinessLayer.Catalog.CategoryServices;
using DtoLayer.CatalogDto.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.ListCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var value = await _categoryService.GetCategoryAsync(id);

            var categoryViewModel = new CategoryViewModel
            {
                GetCategoryDto = value
            };
            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Administrator" });
        }
    }
}