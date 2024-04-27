using DtoLayer.CatalogDto.ProductDto;

namespace BusinessLayer.Catalog.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> ListProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductDto> GetProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> ListProductWithCategoryAsync();
    }
}
