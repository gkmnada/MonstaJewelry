using PresentationUI.Models;

namespace PresentationUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserInfo();
        Task<List<UserViewModel>> ListUser();
        Task<UserViewModel> GetUserById(string id);
    }
}
