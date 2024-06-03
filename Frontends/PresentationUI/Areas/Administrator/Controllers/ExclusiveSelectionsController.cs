using BusinessLayer.Catalog.ExclusiveSelectionsServices;
using BusinessLayer.Catalog.ProductServices;
using DtoLayer.CatalogDto.ExclusiveSelectionsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ExclusiveSelectionsController : Controller
    {
        private readonly IExclusiveSelectionsService _exclusiveSelectionService;
        private readonly IProductService _productService;

        public ExclusiveSelectionsController(IExclusiveSelectionsService exclusiveSelectionService, IProductService productService)
        {
            _exclusiveSelectionService = exclusiveSelectionService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _exclusiveSelectionService.ListExclusiveSelectionsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExclusiveSelections()
        {
            var values = await _productService.ListProductAsync();

            List<SelectListItem> listProducts = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductID
                                                 }).OrderBy(x => x.Text).ToList();
            ViewBag.Products = listProducts;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExclusiveSelections(CreateExclusiveSelectionsDto createExclusiveSelectionsDto)
        {
            var values = await _productService.GetProductAsync(createExclusiveSelectionsDto.ProductID);

            createExclusiveSelectionsDto.ProductName = values.ProductName;
            createExclusiveSelectionsDto.ProductPrice = values.ProductPrice;
            createExclusiveSelectionsDto.ProductImage = values.ProductImage;
            createExclusiveSelectionsDto.ProductDescription = values.ProductDescription;
            createExclusiveSelectionsDto.CategoryID = values.CategoryID;

            await _exclusiveSelectionService.CreateExclusiveSelectionsAsync(createExclusiveSelectionsDto);
            return RedirectToAction("Index", "ExclusiveSelections", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteExclusiveSelections(string id)
        {
            await _exclusiveSelectionService.DeleteExclusiveSelectionsAsync(id);
            return RedirectToAction("Index", "ExclusiveSelections", new { area = "Administrator" });
        }
    }
}
