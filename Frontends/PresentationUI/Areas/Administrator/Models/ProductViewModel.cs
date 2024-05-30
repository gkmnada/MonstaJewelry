using DtoLayer.CatalogDto.ProductDetailDto;
using DtoLayer.CatalogDto.ProductDto;
using DtoLayer.CatalogDto.ProductImageDto;

namespace PresentationUI.Areas.Administrator.Models
{
    public class ProductViewModel
    {
        public GetProductDto GetProductDto { get; set; }
        public UpdateProductDto UpdateProductDto { get; set; }
        public GetProductDetailDto GetProductDetailDto { get; set; }
        public GetProductImageDto GetProductImageDto { get; set; }
        public UpdateProductDetailDto UpdateProductDetailDto { get; set; }
        public UpdateProductImageDto UpdateProductImageDto { get; set; }
    }
}
