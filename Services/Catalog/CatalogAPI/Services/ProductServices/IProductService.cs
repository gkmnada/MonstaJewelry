using CatalogAPI.Dtos.ProductDto;

namespace CatalogAPI.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> ListProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductDto> GetProductAsync(string id);
    }
}
