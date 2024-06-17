namespace DtoLayer.MessageDto.UserMessageDto
{
    public class UpdateMessageDto
    {
        public int message_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}
