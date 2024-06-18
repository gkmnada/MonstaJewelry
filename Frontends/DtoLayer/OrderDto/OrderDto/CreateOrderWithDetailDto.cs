namespace DtoLayer.OrderDto.OrderDto
{
    public class CreateOrderWithDetailDto
    {
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public List<OrderAddressDto> OrderAddresses { get; set; }
    }

    public class OrderDetailDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class OrderAddressDto
    {
        public string AddressID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetail1 { get; set; }
        public string AddressDetail2 { get; set; }
        public string AddressTitle { get; set; }
    }
}
