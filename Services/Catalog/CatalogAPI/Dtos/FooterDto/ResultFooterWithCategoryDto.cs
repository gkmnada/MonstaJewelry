using CatalogAPI.Dtos.CategoryDto;

namespace CatalogAPI.Dtos.FooterDto
{
    public class ResultFooterWithCategoryDto
    {
        public string FooterID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string CategoryID { get; set; }
        public string CouponCode { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
