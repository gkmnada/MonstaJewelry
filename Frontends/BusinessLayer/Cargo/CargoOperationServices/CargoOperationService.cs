using DtoLayer.CargoDto.CargoOperationDto;
using System.Net.Http.Json;

namespace BusinessLayer.Cargo.CargoOperationServices
{
    public class CargoOperationService : ICargoOperationService
    {
        private readonly HttpClient _httpClient;

        public CargoOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            await _httpClient.PostAsJsonAsync("cargooperation", createCargoOperationDto);
        }

        public async Task DeleteCargoOperationAsync(int id)
        {
            await _httpClient.DeleteAsync("cargooperation?id=" + id);
        }

        public async Task<GetCargoOperationDto> GetCargoOperationAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargooperation/getcargooperation?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetCargoOperationDto>();
        }

        public async Task<List<ResultCargoOperationDto>> ListCargoOperationAsync()
        {
            var response = await _httpClient.GetAsync("cargooperation");
            return await response.Content.ReadFromJsonAsync<List<ResultCargoOperationDto>>();
        }

        public async Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _httpClient.PutAsJsonAsync("cargooperation", updateCargoOperationDto);
        }
    }
}
