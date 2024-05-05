using DtoLayer.CatalogDto.ProductDetailDto;

namespace BusinessLayer.Catalog.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> ListProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetProductDetailDto> GetProductDetailAsync(string id);
        Task<GetProductDetailDto> GetProductDetailWithProductAsync(string id);
    }
}
