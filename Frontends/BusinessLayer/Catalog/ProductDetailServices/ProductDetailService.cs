using DtoLayer.CatalogDto.ProductDetailDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("productdetail", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetail?id=" + id);
        }

        public async Task<GetProductDetailDto> GetProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetail/getproductdetail?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailDto>();
            return values;
        }

        public async Task<GetProductDetailDto> GetProductDetailWithProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetail/getproductdetailwithproduct?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailDto>();
            return values;
        }

        public async Task<List<ResultProductDetailDto>> ListProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetail");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("productdetail", updateProductDetailDto);
        }
    }
}
