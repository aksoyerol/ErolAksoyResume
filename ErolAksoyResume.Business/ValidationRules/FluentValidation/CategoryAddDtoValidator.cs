using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category name area cannot be null !");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("You have exceeded the maximum character length.");
        }
    }
}
