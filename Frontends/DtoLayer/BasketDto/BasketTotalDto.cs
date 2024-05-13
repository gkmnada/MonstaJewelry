namespace DtoLayer.BasketDto
{
    public class BasketTotalDto
    {
        public string UserID { get; set; }
        public List<BasketItemDto> BasketItem { get; set; }
        public decimal TotalPrice { get => BasketItem.Sum(x => x.Price * x.Quantity); }
    }
}
