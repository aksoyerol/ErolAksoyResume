using ErolAksoyResume.Dto.Concrete.PortofolioDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.PortofolioDtoValidator
{
    public class PortofolioGeneralDtoValidator : AbstractValidator<PortofolioGeneralDto>
    {
        public PortofolioGeneralDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be null");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text area cannot be null");
            RuleFor(x => x.ImageUrl).MaximumLength(100).WithMessage("Max length 100 character !");
        }
    }
}
