using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.CargoCompanyDto;

namespace BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task itemCreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyDal.CreateCargoCompanyAsync(createCargoCompanyDto);
        }

        public async Task itemDeleteCargoCompanyAsync(int id)
        {
            await _cargoCompanyDal.DeleteCargoCompanyAsync(id);
        }

        public async Task<GetCargoCompanyDto> itemGetCargoCompanyAsync(int id)
        {
            return await _cargoCompanyDal.GetCargoCompanyAsync(id);
        }

        public async Task<List<ResultCargoCompanyDto>> itemListCargoCompanyAsync()
        {
            return await _cargoCompanyDal.ListCargoCompanyAsync();
        }

        public async Task itemUpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyDal.UpdateCargoCompanyAsync(updateCargoCompanyDto);
        }
    }
}
