namespace PresentationUI.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
