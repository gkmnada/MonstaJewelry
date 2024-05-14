namespace Domain.Entities
{
    public class OrderDetail
    {
        public string OrderDetailID { get; } = Guid.NewGuid().ToString("D");
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderID { get; set; }
        public Order Order { get; set; }
    }
}
