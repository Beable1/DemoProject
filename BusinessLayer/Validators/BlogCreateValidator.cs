using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class BlogCreateValidator : AbstractValidator<BlogDto>
    {
        public BlogCreateValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage(" Title is required ");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Content is required ").MinimumLength(140).WithMessage("Content must be longer than 140 characters");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("Please select a category");
        }
    }
}
