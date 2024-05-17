using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class CargoOperation
    {
        [Key]
        public int operation_id { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public DateTime operation_date { get; set; }
    }
}
