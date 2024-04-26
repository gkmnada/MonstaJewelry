using BusinessLayer.Catalog.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.ListCategoryAsync();
            return View(values);
        }
    }
}
