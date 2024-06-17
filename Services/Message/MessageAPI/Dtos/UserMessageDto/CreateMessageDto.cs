namespace MessageAPI.Dtos.UserMessageDto
{
    public class CreateMessageDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
