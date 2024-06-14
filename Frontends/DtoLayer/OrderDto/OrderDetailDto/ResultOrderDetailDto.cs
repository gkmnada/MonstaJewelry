namespace DtoLayer.OrderDto.OrderDetailDto
{
    public class ResultOrderDetailDto
    {
        public string OrderDetailID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderID { get; set; }
    }
}
