using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.CargoDetailDto;

namespace DataAccessLayer.Repositories
{
    public class CargoDetailRepository : ICargoDetailDal
    {
        private readonly DapperContext _context;

        public CargoDetailRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            string query = "inser into cargo_detail (sender_customer, receiver_customer, barcode, company_id) values (@sender_customer, @receiver_customer, @barcode, @company_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@sender_customer", createCargoDetailDto.sender_customer);
            parameters.Add("@receiver_customer", createCargoDetailDto.receiver_customer);
            parameters.Add("@barcode", createCargoDetailDto.barcode);
            parameters.Add("@company_id", createCargoDetailDto.company_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCargoDetailAsync(int id)
        {
            string query = "delete from cargo_detail where detail_id = @detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@detail_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCargoDetailDto> GetCargoDetailAsync(int id)
        {
            string query = "select * from cargo_detail where detail_id = @detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@detail_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCargoDetailDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCargoDetailDto>> ListCargoDetailAsync()
        {
            string query = "select * from cargo_detail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCargoDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            string query = "update cargo_detail set sender_customer = @sender_customer, receiver_customer = @receiver_customer, barcode = @barcode, company_id = @company_id where detail_id = @detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@sender_customer", updateCargoDetailDto.sender_customer);
            parameters.Add("@receiver_customer", updateCargoDetailDto.receiver_customer);
            parameters.Add("@barcode", updateCargoDetailDto.barcode);
            parameters.Add("@company_id", updateCargoDetailDto.company_id);
            parameters.Add("@detail_id", updateCargoDetailDto.detail_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
