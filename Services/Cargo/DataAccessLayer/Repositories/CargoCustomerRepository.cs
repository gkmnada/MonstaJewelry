using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.CargoCustomerDto;

namespace DataAccessLayer.Repositories
{
    public class CargoCustomerRepository : ICargoCustomerDal
    {
        private readonly DapperContext _dapperContext;

        public CargoCustomerRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            string query = "inser into cargo_customer (name, surname, email, phone, address, city, district) values (@name, @surname, @email, @phone, @address, @city, @district)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createCargoCustomerDto.name);
            parameters.Add("@surname", createCargoCustomerDto.surname);
            parameters.Add("@email", createCargoCustomerDto.email);
            parameters.Add("@phone", createCargoCustomerDto.phone);
            parameters.Add("@address", createCargoCustomerDto.address);
            parameters.Add("@city", createCargoCustomerDto.city);
            parameters.Add("@district", createCargoCustomerDto.district);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCargoCustomerAsync(int id)
        {
            string query = "delete from cargo_customer where customer_id = @customer_id";
            var parameters = new DynamicParameters();
            parameters.Add("@customer_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCargoCustomerDto> GetCargoCustomerAsync(int id)
        {
            string query = "select * from cargo_customer where customer_id = @customer_id";
            var parameters = new DynamicParameters();
            parameters.Add("@customer_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCargoCustomerDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCargoCustomerDto>> ListCargoCustomerAsync()
        {
            string query = "select * from cargo_customer";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCargoCustomerDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            string query = "update cargo_customer set name = @name, surname = @surname, email = @email, phone = @phone, address = @address, city = @city, district = @district where customer_id = @customer_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateCargoCustomerDto.name);
            parameters.Add("@surname", updateCargoCustomerDto.surname);
            parameters.Add("@email", updateCargoCustomerDto.email);
            parameters.Add("@phone", updateCargoCustomerDto.phone);
            parameters.Add("@address", updateCargoCustomerDto.address);
            parameters.Add("@city", updateCargoCustomerDto.city);
            parameters.Add("@district", updateCargoCustomerDto.district);
            parameters.Add("@customer_id", updateCargoCustomerDto.customer_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
