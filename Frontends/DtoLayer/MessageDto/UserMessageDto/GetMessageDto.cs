namespace DtoLayer.MessageDto.UserMessageDto
{
    public class GetMessageDto
    {
        public int message_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public bool status { get; set; }
    }
}
