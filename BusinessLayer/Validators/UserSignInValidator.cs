using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Models;
using FluentValidation;

namespace BusinessLayer.Validators
{
    

    public class SignInDtoValidator : AbstractValidator<UserSignInViewModel>
    {
        public SignInDtoValidator()
        {
            RuleFor(x => x.username)
                .NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz.")
                .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olabilir.");

            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Lütfen şifre giriniz.");
                
        }
    }
}
