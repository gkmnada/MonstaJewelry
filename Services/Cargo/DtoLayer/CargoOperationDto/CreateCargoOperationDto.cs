namespace DtoLayer.CargoOperationDto
{
    public class CreateCargoOperationDto
    {
        public string barcode { get; set; }
        public string description { get; set; }
        public DateTime operation_date { get; set; }
    }
}
