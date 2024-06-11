using DtoLayer.CargoDto.CargoCustomerDto;
using System.Net.Http.Json;

namespace BusinessLayer.Cargo.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _httpClient.PostAsJsonAsync("cargocustomer", createCargoCustomerDto);
        }

        public async Task DeleteCargoCustomerAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocustomer?id=" + id);
        }

        public async Task<GetCargoCustomerDto> GetCargoCustomerAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargocustomer/getcargocustomer?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetCargoCustomerDto>();
        }

        public async Task<List<ResultCargoCustomerDto>> ListCargoCustomerAsync()
        {
            var response = await _httpClient.GetAsync("cargocustomer");
            return await response.Content.ReadFromJsonAsync<List<ResultCargoCustomerDto>>();
        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _httpClient.PutAsJsonAsync("cargocustomer", updateCargoCustomerDto);
        }
    }
}
