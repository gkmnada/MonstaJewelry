using PresentationUI.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace PresentationUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService, IHttpContextAccessor httpContextAccessor)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login");
                return response;
            }
            return response;
        }
    }
}
