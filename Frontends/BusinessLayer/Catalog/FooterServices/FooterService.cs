using DtoLayer.CatalogDto.FooterDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.FooterServices
{
    public class FooterService : IFooterService
    {
        private readonly HttpClient _client;

        public FooterService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateFooterAsync(CreateFooterDto createFooterDto)
        {
            await _client.PostAsJsonAsync("footer", createFooterDto);
        }

        public async Task DeleteFooterAsync(string id)
        {
            await _client.DeleteAsync("footer?id=" + id);
        }

        public async Task<GetFooterDto> GetFooterAsync(string id)
        {
            var response = await _client.GetAsync("footer?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<GetFooterDto>();
            return values;
        }

        public async Task<List<ResultFooterDto>> ListFooterAsync()
        {
            var response = await _client.GetAsync("footer");
            var values = await response.Content.ReadFromJsonAsync<List<ResultFooterDto>>();
            return values;
        }

        public async Task<List<ResultFooterWithCategoryDto>> ListFooterWithCategoryAsync()
        {
            var response = await _client.GetAsync("footer/listfooterwithcategory");
            var values = await response.Content.ReadFromJsonAsync<List<ResultFooterWithCategoryDto>>();
            return values;
        }

        public async Task UpdateFooterAsync(UpdateFooterDto updateFooterDto)
        {
            await _client.PutAsJsonAsync("footer", updateFooterDto);
        }
    }
}
