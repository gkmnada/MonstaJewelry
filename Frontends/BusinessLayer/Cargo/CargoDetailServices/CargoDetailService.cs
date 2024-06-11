using DtoLayer.CargoDto.CargoDetailDto;
using System.Net.Http.Json;

namespace BusinessLayer.Cargo.CargoDetailServices
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly HttpClient _httpClient;

        public CargoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            await _httpClient.PostAsJsonAsync("cargodetail", createCargoDetailDto);
        }

        public async Task DeleteCargoDetailAsync(int id)
        {
            await _httpClient.DeleteAsync("cargodetail?id=" + id);
        }

        public async Task<GetCargoDetailDto> GetCargoDetailAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargodetail/getcargodetail?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetCargoDetailDto>();
        }

        public async Task<List<ResultCargoDetailDto>> ListCargoDetailAsync()
        {
            var response = await _httpClient.GetAsync("cargodetail");
            return await response.Content.ReadFromJsonAsync<List<ResultCargoDetailDto>>();
        }

        public async Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _httpClient.PutAsJsonAsync("cargodetail", updateCargoDetailDto);
        }
    }
}
