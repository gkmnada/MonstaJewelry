using DtoLayer.CatalogDto.SliderDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _client;

        public SliderService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            await _client.PostAsJsonAsync("slider", createSliderDto);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _client.DeleteAsync("slider?id=" + id);
        }

        public async Task<GetSliderDto> GetSliderAsync(string id)
        {
            var responseMessage = await _client.GetAsync("slider/getslider?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetSliderDto>();
            return values;
        }

        public async Task<List<ResultSliderDto>> ListSliderAsync()
        {
            var responseMessage = await _client.GetAsync("slider");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSliderDto>>();
            return values;
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            await _client.PutAsJsonAsync("slider", updateSliderDto);
        }
    }
}
