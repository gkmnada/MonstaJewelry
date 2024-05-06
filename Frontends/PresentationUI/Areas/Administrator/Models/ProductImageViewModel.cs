using DtoLayer.CatalogDto.ProductDto;
using DtoLayer.CatalogDto.ProductImageDto;

namespace PresentationUI.Areas.Administrator.Models
{
    public class ProductImageViewModel
    {
        public GetProductDto GetProductDto { get; set; }
        public CreateProductImageDto CreateProductImageDto { get; set; }
        public GetProductImageDto GetProductImageDto { get; set; }
        public UpdateProductImageDto UpdateProductImageDto { get; set; }
    }
}
