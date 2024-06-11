using DtoLayer.CargoDto.CargoOperationDto;

namespace BusinessLayer.Cargo.CargoOperationServices
{
    public interface ICargoOperationService
    {
        Task<List<ResultCargoOperationDto>> ListCargoOperationAsync();
        Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto);
        Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto);
        Task DeleteCargoOperationAsync(int id);
        Task<GetCargoOperationDto> GetCargoOperationAsync(int id);
    }
}
