using DtoLayer.IdentityDto.LoginDto;
using FluentValidation;

namespace PresentationUI.Areas.Administrator.ValidationRules.Login
{
    public class LoginValidator : AbstractValidator<CreateLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Girin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Girin");
        }
    }
}
