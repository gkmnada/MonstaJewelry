using DtoLayer.CatalogDto.ProductDetailDto;
using DtoLayer.CatalogDto.ProductDto;

namespace PresentationUI.Areas.Administrator.Models
{
    public class ProductDetailViewModel
    {
        public GetProductDto GetProductDto { get; set; }
        public CreateProductDetailDto CreateProductDetailDto { get; set; }
        public GetProductDetailDto GetProductDetailDto { get; set; }
        public UpdateProductDetailDto UpdateProductDetailDto { get; set; }
    }
}
