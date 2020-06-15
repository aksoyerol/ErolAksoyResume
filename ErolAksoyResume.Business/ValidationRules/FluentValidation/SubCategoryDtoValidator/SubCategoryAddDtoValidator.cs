using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation
{
    public class SubCategoryAddDtoValidator : AbstractValidator<SubCategoryAddDto>
    {
        public SubCategoryAddDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category name area cannot be null !");
            RuleFor(x => x.CategoryId).NotNull().ExclusiveBetween(0,int.MaxValue).WithMessage("Please Base Category's select ! ");
        }
    }
}
