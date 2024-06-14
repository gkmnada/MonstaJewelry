﻿namespace DtoLayer.OrderDto.OrderDto
{
    public class ResultOrderDto
    {
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
    }
}
