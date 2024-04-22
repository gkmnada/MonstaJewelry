using DtoLayer.IdentityDto.LoginDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PresentationUI.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PresentationUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory clientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _clientFactory = clientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                string token;
                DateTime expireDate;

                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        RequestUri = new Uri("https://localhost:5001/connect/token"),
                        Method = HttpMethod.Post,
                        Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "client_id", "AdminClient" },
                            { "client_secret", "adminsecret" },
                            { "grant_type", "password" },
                            { "username", loginDto.UserName},
                            { "password", loginDto.Password}
                        })
                    };

                    using (var responseMessage = await httpClient.SendAsync(request))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            jsonData = await responseMessage.Content.ReadAsStringAsync();
                            var tokenResponse = JObject.Parse(jsonData);
                            token = tokenResponse.Value<string>("access_token");
                            expireDate = DateTime.Now.AddSeconds(tokenResponse.Value<int>("expires_in"));

                            if (token != null)
                            {
                                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                                var tokenRead = handler.ReadJwtToken(token);
                                var claims = tokenRead.Claims.ToList();

                                claims.Add(new Claim("monstaToken", token));
                                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                                var authProperties = new AuthenticationProperties
                                {
                                    ExpiresUtc = expireDate,
                                    IsPersistent = true
                                };

                                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                                var user = _loginService.GetUserID;
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            loginDto.UserName = "gkmenada";
            loginDto.Password = "Ada2024++";
            await _identityService.SignIn(loginDto);
            return RedirectToAction("Index", "User");
        }
    }
}
