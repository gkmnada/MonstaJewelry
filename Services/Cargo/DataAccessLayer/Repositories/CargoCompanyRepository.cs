using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.CargoCompanyDto;

namespace DataAccessLayer.Repositories
{
    public class CargoCompanyRepository : ICargoCompanyDal
    {
        private readonly DapperContext _dapperContext;

        public CargoCompanyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            string query = "insert into cargo_company (company_name) values (@company_name)";
            var parameters = new DynamicParameters();
            parameters.Add("@company_name", createCargoCompanyDto.company_name);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            string query = "delete from cargo_company where company_id = @company_id";
            var parameters = new DynamicParameters();
            parameters.Add("@company_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCargoCompanyDto> GetCargoCompanyAsync(int id)
        {
            string query = "select * from cargo_company where company_id = @company_id";
            var parameters = new DynamicParameters();
            parameters.Add("@company_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCargoCompanyDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCargoCompanyDto>> ListCargoCompanyAsync()
        {
            string query = "select * from cargo_company";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCargoCompanyDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            string query = "update cargo_company set company_name = @company_name where company_id = @company_id";
            var parameters = new DynamicParameters();
            parameters.Add("@company_name", updateCargoCompanyDto.company_name);
            parameters.Add("@company_id", updateCargoCompanyDto.company_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
