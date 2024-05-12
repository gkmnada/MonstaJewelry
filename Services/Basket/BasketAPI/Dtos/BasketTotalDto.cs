namespace BasketAPI.Dtos
{
    public class BasketTotalDto
    {
        public string UserID { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItem { get; set; }
        public decimal TotalPrice { get => BasketItem.Sum(x => x.Price * x.Quantity); }
    }
}
