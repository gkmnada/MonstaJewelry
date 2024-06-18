﻿namespace Domain.Entities
{
    public class OrderAddress
    {
        public string OrderAddressID { get; } = Guid.NewGuid().ToString("D");
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
        public string OrderID { get; set; }
        public Order Order { get; set; }
    }
}
