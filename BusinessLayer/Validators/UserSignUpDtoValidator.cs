using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.DTOs;
using FluentValidation;

namespace BusinessLayer.Validators
{
 

    public class UserSignUpDtoValidator : AbstractValidator<UserSignUpDto>
    {
        public UserSignUpDtoValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Lütfen ad soyad giriniz.")
                .MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz.")
                .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olabilir.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Lütfen mail giriniz.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Lütfen şifre giriniz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor.");

            // Şifrenin en az bir büyük harf, bir küçük harf ve bir sayı içermesi kuralı:
            RuleFor(x => x.Password).Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.");
            RuleFor(x => x.Password).Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.");
            RuleFor(x => x.Password).Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
        }
    }

}
