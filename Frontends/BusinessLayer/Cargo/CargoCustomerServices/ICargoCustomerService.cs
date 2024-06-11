using DtoLayer.CargoDto.CargoCustomerDto;

namespace BusinessLayer.Cargo.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> ListCargoCustomerAsync();
        Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);
        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
        Task DeleteCargoCustomerAsync(int id);
        Task<GetCargoCustomerDto> GetCargoCustomerAsync(int id);
    }
}
