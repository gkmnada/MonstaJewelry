namespace DtoLayer.CargoDto.CargoOperationDto
{
    public class GetCargoOperationDto
    {
        public int operation_id { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public DateTime operation_date { get; set; }
    }
}
