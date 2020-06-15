using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation
{
    public class SubCategoryUpdateDtoValidator : AbstractValidator<SubCategoryUpdateDto>
    {
        public SubCategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category name area cannot be null !");
            RuleFor(x => x.CategoryId).NotNull().ExclusiveBetween(0, int.MaxValue).WithMessage("Please Base Category's select ! ");
        }
    }
}
