namespace PresentationUI.Settings
{
    public class ClientSettings
    {
        public Client VisitorClient { get; set; }
        public Client AdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
