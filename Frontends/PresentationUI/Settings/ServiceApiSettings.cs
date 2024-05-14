namespace PresentationUI.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotApi { get; set; }
        public string IdentityApi { get; set; }
        public ServiceApi Catalog { get; set; }
        public ServiceApi Comment { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi Order { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
