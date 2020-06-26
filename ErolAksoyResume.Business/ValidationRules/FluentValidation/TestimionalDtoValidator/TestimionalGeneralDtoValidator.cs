using ErolAksoyResume.Dto.Concrete.TestimionalDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.TestimionalDtoValidator
{
    public class TestimionalGeneralDtoValidator : AbstractValidator<TestimionalGeneralDto>
    {
        public TestimionalGeneralDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This area cannot be null");
            RuleFor(x => x.Text).NotEmpty().WithMessage("This area cannot be null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("This area cannot be null");
        }
    }
}
