using DtoLayer.IdentityDto.RegisterDto;
using FluentValidation;

namespace PresentationUI.Areas.Administrator.ValidationRules.Register
{
    public class RegisterValidator : AbstractValidator<CreateRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Girin")
                .MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz")
                .Must(IsValidName).WithMessage("Adınız Özel Karakter İçeremez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyadınızı Girin")
                .MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz")
                .Must(IsValidName).WithMessage("Soyadınız Özel Karakter İçeremez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Mail Adresinizi Girin")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Bir Kullanıcı Adı Girin")
                .MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz")
                .Must(IsValidName).WithMessage("Kullanıcı Adınız Özel Karakter İçeremez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Bir Şifre Girin");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifrenizi Tekrardan Girin")
                .Equal(z => z.Password).WithMessage("Şifreler Uyumlu Değil. Lütfen Şifrenizi Tekrardan Girin.");
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && !name.Any(x => char.IsPunctuation(x));
        }
    }
}
