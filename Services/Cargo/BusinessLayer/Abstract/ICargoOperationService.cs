using DtoLayer.CargoOperationDto;

namespace BusinessLayer.Abstract
{
    public interface ICargoOperationService
    {
        Task<List<ResultCargoOperationDto>> itemListCargoOperationAsync();
        Task itemCreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto);
        Task itemUpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto);
        Task itemDeleteCargoOperationAsync(int id);
        Task<GetCargoOperationDto> itemGetCargoOperationAsync(int id);
    }
}
