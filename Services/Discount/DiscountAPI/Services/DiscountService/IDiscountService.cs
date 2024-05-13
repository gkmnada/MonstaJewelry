using DiscountAPI.Dtos.CouponDto;

namespace DiscountAPI.Services.DiscountService
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> ListCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetCouponDto> GetCouponAsync(int id);
    }
}
