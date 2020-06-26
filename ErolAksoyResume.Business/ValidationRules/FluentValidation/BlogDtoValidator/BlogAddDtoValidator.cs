using ErolAksoyResume.Dto.Concrete.BlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.BlogDtoValidator
{
    public class BlogAddDtoValidator : AbstractValidator<BlogAddDto>
    {
        public BlogAddDtoValidator()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text area cannot be null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title area cannot be null");
            //RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Please select Category").ExclusiveBetween(0, int.MaxValue).WithMessage("Please enter valid range!");
            RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Please select Sub Category").ExclusiveBetween(0, int.MaxValue).WithMessage("Please enter valid range!");

        }
    }
}
