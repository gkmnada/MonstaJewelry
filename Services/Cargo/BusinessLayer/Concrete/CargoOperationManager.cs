using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.CargoOperationDto;

namespace BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public async Task itemCreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            await _cargoOperationDal.CreateCargoOperationAsync(createCargoOperationDto);
        }

        public async Task itemDeleteCargoOperationAsync(int id)
        {
            await _cargoOperationDal.DeleteCargoOperationAsync(id);
        }

        public async Task<GetCargoOperationDto> itemGetCargoOperationAsync(int id)
        {
            return await _cargoOperationDal.GetCargoOperationAsync(id);
        }

        public async Task<List<ResultCargoOperationDto>> itemListCargoOperationAsync()
        {
            return await _cargoOperationDal.ListCargoOperationAsync();
        }

        public async Task itemUpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _cargoOperationDal.UpdateCargoOperationAsync(updateCargoOperationDto);
        }
    }
}
