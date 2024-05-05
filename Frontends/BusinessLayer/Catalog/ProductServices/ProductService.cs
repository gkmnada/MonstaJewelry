using DtoLayer.CatalogDto.ProductDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("product?id=" + id);
        }

        public async Task<GetProductDto> GetProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("product/getproduct?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetProductDto>();
            return values;
        }

        public async Task<List<ResultProductDto>> ListProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> ListProductByCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("product/listproductbycategory?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> ListProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product/listproductwithcategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("product", updateProductDto);
        }
    }
}
