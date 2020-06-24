using ErolAksoyResume.Dto.Concrete.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.SkillDtoValidator
{
    public class SkillAddDtoValidator : AbstractValidator<SkillAddDto>
    {
        public SkillAddDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100).WithMessage("Title cannot be null and max character length 100 !");
            RuleFor(x => x.LevelPercent).NotEmpty().MaximumLength(3).WithMessage("Please enter valid value ! And cannot empty this area");
            RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Please select sub category !");
        }
    }
}
