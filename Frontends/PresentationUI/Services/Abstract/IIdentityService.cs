using DtoLayer.IdentityDto.LoginDto;

namespace PresentationUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(LoginDto loginDto);
    }
}
