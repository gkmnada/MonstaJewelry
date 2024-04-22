using PresentationUI.Models;

namespace PresentationUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserInfo();
    }
}
