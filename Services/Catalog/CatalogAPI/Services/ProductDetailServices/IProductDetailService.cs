using CatalogAPI.Dtos.ProductDetailDto;

namespace CatalogAPI.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> ListProductDetailAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetProductDetailDto> GetProductDetailAsync(string id);
        Task<GetProductDetailDto> GetProductDetailWithProductAsync(string id);
    }
}
