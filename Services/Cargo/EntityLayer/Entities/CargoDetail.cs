using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class CargoDetail
    {
        [Key]
        public int detail_id { get; set; }
        public string sender_customer { get; set; }
        public string receiver_customer { get; set; }
        public string barcode { get; set; }
        public int company_id { get; set; }
    }
}
