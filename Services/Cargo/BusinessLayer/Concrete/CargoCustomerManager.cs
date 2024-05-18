using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.CargoCustomerDto;

namespace BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task itemCreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _cargoCustomerDal.CreateCargoCustomerAsync(createCargoCustomerDto);
        }

        public async Task itemDeleteCargoCustomerAsync(int id)
        {
            await _cargoCustomerDal.DeleteCargoCustomerAsync(id);
        }

        public async Task<GetCargoCustomerDto> itemGetCargoCustomerAsync(int id)
        {
            return await _cargoCustomerDal.GetCargoCustomerAsync(id);
        }

        public async Task<List<ResultCargoCustomerDto>> itemListCargoCustomerAsync()
        {
            return await _cargoCustomerDal.ListCargoCustomerAsync();
        }

        public async Task itemUpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _cargoCustomerDal.UpdateCargoCustomerAsync(updateCargoCustomerDto);
        }
    }
}
