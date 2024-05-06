using DtoLayer.CatalogDto.ProductImageDto;

namespace BusinessLayer.Catalog.ProductImageService
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> ListProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageDto> GetProductImageAsync(string id);
        Task<GetProductImageDto> GetProductImageWithProductAsync(string id);
    }
}
