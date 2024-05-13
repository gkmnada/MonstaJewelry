namespace DiscountAPI.Dtos.CouponDto
{
    public class UpdateCouponDto
    {
        public int CouponID { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidityDate { get; set; }
    }
}
