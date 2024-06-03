using Dapper;
using DiscountAPI.Context;
using DiscountAPI.Dtos.CouponDto;

namespace DiscountAPI.Services.DiscountService
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidityDate) VALUES (@Code, @Rate, @IsActive, @ValidityDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidityDate", createCouponDto.ValidityDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCouponDto> GetCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<GetCouponDto>(query, parameters);
                return coupon;
            }
        }

        public async Task<GetCouponDto> GetCouponCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCouponDto>> ListCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var coupons = await connection.QueryAsync<ResultCouponDto>(query);
                return coupons.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidityDate = @ValidityDate WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", updateCouponDto.CouponID);
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidityDate", updateCouponDto.ValidityDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
