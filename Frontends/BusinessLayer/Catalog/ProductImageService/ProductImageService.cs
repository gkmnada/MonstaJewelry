using DtoLayer.CatalogDto.ProductImageDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.ProductImageService
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("productimage", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimage?id=" + id);
        }

        public async Task<GetProductImageDto> GetProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimage/getproductimage?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<GetProductImageDto>();
        }

        public async Task<GetProductImageDto> GetProductImageWithProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimage/getproductimagewithproduct?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<GetProductImageDto>();
        }

        public async Task<List<ResultProductImageDto>> ListProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimage?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("productimage", updateProductImageDto);
        }
    }
}
