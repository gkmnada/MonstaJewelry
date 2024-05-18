using DtoLayer.CargoOperationDto;

namespace DataAccessLayer.Abstract
{
    public interface ICargoOperationDal
    {
        Task<List<ResultCargoOperationDto>> ListCargoOperationAsync();
        Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto);
        Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto);
        Task DeleteCargoOperationAsync(int id);
        Task<GetCargoOperationDto> GetCargoOperationAsync(int id);
    }
}
