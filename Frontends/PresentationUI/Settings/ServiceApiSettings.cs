namespace PresentationUI.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotApi { get; set; }
        public string IdentityApi { get; set; }
        public ServiceApi Catalog { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
