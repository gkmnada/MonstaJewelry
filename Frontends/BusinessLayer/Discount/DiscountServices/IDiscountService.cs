using DtoLayer.DiscountDto.CouponDto;

namespace BusinessLayer.Discount.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetCouponDto> GetCouponCodeAsync(string code);
        Task<List<ResultCouponDto>> ListCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetCouponDto> GetCouponAsync(int id);
    }
}
