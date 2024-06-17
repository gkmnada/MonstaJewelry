using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.FooterServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.ViewComponents.Layout
{
    public class Footer : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IFooterService _footerService;

        public Footer(ICategoryService categoryService, IFooterService footerService)
        {
            _categoryService = categoryService;
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.ListCategoryAsync();
            var footer = await _footerService.ListFooterWithCategoryAsync();

            var footerViewModel = new FooterViewModel
            {
                ResultCategoryDto = categories,
                ResultFooterWithCategoryDto = footer
            };
            return View(footerViewModel);
        }
    }
}
