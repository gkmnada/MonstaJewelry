using DtoLayer.CargoDetailDto;

namespace DataAccessLayer.Abstract
{
    public interface ICargoDetailDal
    {
        Task<List<ResultCargoDetailDto>> ListCargoDetailAsync();
        Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task DeleteCargoDetailAsync(int id);
        Task<GetCargoDetailDto> GetCargoDetailAsync(int id);
    }
}
