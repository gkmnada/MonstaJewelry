using DtoLayer.CargoDto.CargoCompanyDto;
using System.Net.Http.Json;

namespace BusinessLayer.Cargo.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync("cargocompany", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompany?id=" + id);
        }

        public async Task<GetCargoCompanyDto> GetCargoCompanyAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargocompany/getcargocompany?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetCargoCompanyDto>();
        }

        public async Task<List<ResultCargoCompanyDto>> ListCargoCompanyAsync()
        {
            var response = await _httpClient.GetAsync("cargocompany");
            return await response.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync("cargocompany", updateCargoCompanyDto);
        }
    }
}
