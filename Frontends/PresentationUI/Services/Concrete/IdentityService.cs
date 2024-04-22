using DtoLayer.IdentityDto.LoginDto;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PresentationUI.Services.Abstract;
using PresentationUI.Settings;
using System.Security.Claims;

namespace PresentationUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient client, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityApi,
            });

            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            var refreshTokenResponse = await _client.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = discoveryEndpoint.TokenEndpoint,
                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                RefreshToken = refreshToken,
            });

            var authenticationTokens = new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = refreshTokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = refreshTokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(refreshTokenResponse.ExpiresIn).ToString()
                },
            };

            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

            var properties = result.Properties;
            properties.StoreTokens(authenticationTokens);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

            return true;
        }

        public async Task<bool> SignIn(LoginDto loginDto)
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityApi,
            });

            var passwordTokenResponse = await _client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = discoveryEndpoint.TokenEndpoint,
                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                UserName = loginDto.UserName,
                Password = loginDto.Password,
            });

            var userInfo = await _client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = discoveryEndpoint.UserInfoEndpoint,
                Token = passwordTokenResponse.AccessToken,
            });

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = passwordTokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = passwordTokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(passwordTokenResponse.ExpiresIn).ToString()
                },
            });

            authenticationProperties.IsPersistent = false;

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return true;
        }
    }
}
