using DtoLayer.CatalogDto.CategoryDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("category", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _client.DeleteAsync("category?id=" + id);
        }

        public async Task<GetCategoryDto> GetCategoryAsync(string id)
        {
            var responseMessage = await _client.GetAsync("category/getcategory?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCategoryDto>();
            return values;
        }

        public async Task<List<ResultCategoryDto>> ListCategoryAsync()
        {
            var responseMessage = await _client.GetAsync("category");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync("category", updateCategoryDto);
        }
    }
}
