using BusinessLayer.Catalog.ExclusiveSelectionsServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class ExclusiveSelections : ViewComponent
    {
        private readonly IExclusiveSelectionsService _exclusiveSelectionsService;

        public ExclusiveSelections(IExclusiveSelectionsService exclusiveSelectionsService)
        {
            _exclusiveSelectionsService = exclusiveSelectionsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _exclusiveSelectionsService.ListExclusiveSelectionsAsync();
            if (values == null)
            {
                return Content("Öne Çıkan Ürün Bulunamadı");
            }
            return View(values);
        }
    }
}
