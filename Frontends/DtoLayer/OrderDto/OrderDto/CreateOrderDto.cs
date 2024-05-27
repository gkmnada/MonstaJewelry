namespace DtoLayer.OrderDto.OrderDto
{
    public class CreateOrderDto
    {
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
    }
}
