using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.CargoDetailDto;

namespace BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task itemCreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailDal.CreateCargoDetailAsync(createCargoDetailDto);
        }

        public async Task itemDeleteCargoDetailAsync(int id)
        {
            await _cargoDetailDal.DeleteCargoDetailAsync(id);
        }

        public async Task<GetCargoDetailDto> itemGetCargoDetailAsync(int id)
        {
            return await _cargoDetailDal.GetCargoDetailAsync(id);
        }

        public async Task<List<ResultCargoDetailDto>> itemListCargoDetailAsync()
        {
            return await _cargoDetailDal.ListCargoDetailAsync();
        }

        public async Task itemUpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailDal.UpdateCargoDetailAsync(updateCargoDetailDto);
        }
    }
}
