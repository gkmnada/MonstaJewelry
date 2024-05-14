namespace Domain.Entities
{
    public class Address
    {
        public string AddressID { get; } = Guid.NewGuid().ToString("D");
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
        public string OrderNotes { get; set; }
    }
}
