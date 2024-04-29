using BusinessLayer.Catalog.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Layout
{
    public class Footer : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public Footer(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.ListCategoryAsync();
            return View(values);
        }
    }
}
