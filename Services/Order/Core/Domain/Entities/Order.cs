﻿namespace Domain.Entities
{
    public class Order
    {
        public string OrderID { get; } = Guid.NewGuid().ToString("D");
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<OrderAddress> OrderAddresses { get; set; }
    }
}
