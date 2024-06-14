using Microsoft.AspNetCore.Authorization;
using PresentationUI.Models;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserViewModel> GetUserInfo()
        {
            return await _client.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }

        public async Task<List<UserViewModel>> ListUser()
        {
            return await _client.GetFromJsonAsync<List<UserViewModel>>("/api/user/listuser");
        }
    }
}
