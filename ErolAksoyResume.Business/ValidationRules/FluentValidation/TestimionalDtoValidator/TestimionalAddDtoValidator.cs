using ErolAksoyResume.Dto.Concrete.TestimionalDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.TestimionalDtoValidator
{
    public class TestimionalAddDtoValidator : AbstractValidator<TestimionalAddDto>
    {
        public TestimionalAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This area cannot be null");
            RuleFor(x => x.Text).NotEmpty().WithMessage("This area cannot be null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("This area cannot be null");
        }

    }
}
