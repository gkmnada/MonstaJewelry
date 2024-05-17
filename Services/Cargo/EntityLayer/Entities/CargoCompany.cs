using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class CargoCompany
    {
        [Key]
        public int company_id { get; set; }
        public string company_name { get; set; }
    }
}
