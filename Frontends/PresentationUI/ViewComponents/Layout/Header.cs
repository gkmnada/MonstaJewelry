using BusinessLayer.Catalog.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Layout
{
    public class Header : ViewComponent
    {
        public readonly ICategoryService _categoryService;

        public Header(ICategoryService categoryService)
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
