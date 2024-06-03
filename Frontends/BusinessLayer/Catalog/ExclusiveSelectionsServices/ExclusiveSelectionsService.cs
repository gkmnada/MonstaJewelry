using DtoLayer.CatalogDto.ExclusiveSelectionsDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.ExclusiveSelectionsServices
{
    public class ExclusiveSelectionsService : IExclusiveSelectionsService
    {
        private readonly HttpClient _httpClient;

        public ExclusiveSelectionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateExclusiveSelectionsAsync(CreateExclusiveSelectionsDto createExclusiveSelectionsDto)
        {
            await _httpClient.PostAsJsonAsync("exclusiveselections", createExclusiveSelectionsDto);
        }

        public async Task DeleteExclusiveSelectionsAsync(string id)
        {
            await _httpClient.DeleteAsync("exclusiveselections?id=" + id);
        }

        public async Task<GetExclusiveSelectionsDto> GetExclusiveSelectionsAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("exclusiveselections/getexclusiveselections?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetExclusiveSelectionsDto>();
            return values;
        }

        public async Task<List<ResultExclusiveSelectionsDto>> ListExclusiveSelectionsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("exclusiveselections");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultExclusiveSelectionsDto>>();
            return values;
        }

        public async Task UpdateExclusiveSelectionsAsync(UpdateExclusiveSelectionsDto updateExclusiveSelectionsDto)
        {
            await _httpClient.PutAsJsonAsync("exclusiveselections", updateExclusiveSelectionsDto);
        }
    }
}
