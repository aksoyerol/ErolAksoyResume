using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation
{
    public class CategoryListDtoValidator : AbstractValidator<CategoryListDto>
    {
        public CategoryListDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name area cannot be null !");
        }
    }
}
