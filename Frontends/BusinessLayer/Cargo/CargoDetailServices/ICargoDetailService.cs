using DtoLayer.CargoDto.CargoDetailDto;

namespace BusinessLayer.Cargo.CargoDetailServices
{
    public interface ICargoDetailService
    {
        Task<List<ResultCargoDetailDto>> ListCargoDetailAsync();
        Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task DeleteCargoDetailAsync(int id);
        Task<GetCargoDetailDto> GetCargoDetailAsync(int id);
    }
}
