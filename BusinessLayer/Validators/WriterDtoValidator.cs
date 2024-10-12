using EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class WriterDtoValidator : AbstractValidator<WriterDto>
    {
        public WriterDtoValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.WriterMail).NotNull().WithMessage("Email is required").NotEmpty().WithMessage("Email is required ");
            RuleFor(x => x.WriterPassword).NotNull().WithMessage("Password is required").NotEmpty().WithMessage("Password is required ");

        }
    }
}
