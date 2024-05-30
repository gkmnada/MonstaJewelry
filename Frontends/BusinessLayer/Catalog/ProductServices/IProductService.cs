using DtoLayer.CatalogDto.ProductDto;

namespace BusinessLayer.Catalog.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> ListProductAsync();
        Task CreateProductAsync(CreateProductWithDetailDto createProductWithDetailDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductDto> GetProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> ListProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> ListProductByCategoryAsync(string id);
    }
}
