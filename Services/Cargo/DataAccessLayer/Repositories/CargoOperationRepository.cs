using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.CargoOperationDto;

namespace DataAccessLayer.Repositories
{
    public class CargoOperationRepository : ICargoOperationDal
    {
        private readonly DapperContext _context;

        public CargoOperationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            string query = "insert into cargo_operation (barcode, description, operation_date) values (@barcode, @description, @operation_date)";
            var parameters = new DynamicParameters();
            parameters.Add("@barcode", createCargoOperationDto.barcode);
            parameters.Add("@description", createCargoOperationDto.description);
            parameters.Add("@operation_date", createCargoOperationDto.operation_date);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCargoOperationAsync(int id)
        {
            string query = "delete from cargo_operation where operation_id = @operation_id";
            var parameters = new DynamicParameters();
            parameters.Add("@operation_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCargoOperationDto> GetCargoOperationAsync(int id)
        {
            string query = "select * from cargo_operation where operation_id = @operation_id";
            var parameters = new DynamicParameters();
            parameters.Add("@operation_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCargoOperationDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCargoOperationDto>> ListCargoOperationAsync()
        {
            string query = "select * from cargo_operation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCargoOperationDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            string query = "update cargo_operation set barcode = @barcode, description = @description, operation_date = @operation_date where operation_id = @operation_id";
            var parameters = new DynamicParameters();
            parameters.Add("@operation_id", updateCargoOperationDto.operation_id);
            parameters.Add("@barcode", updateCargoOperationDto.barcode);
            parameters.Add("@description", updateCargoOperationDto.description);
            parameters.Add("@operation_date", updateCargoOperationDto.operation_date);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
