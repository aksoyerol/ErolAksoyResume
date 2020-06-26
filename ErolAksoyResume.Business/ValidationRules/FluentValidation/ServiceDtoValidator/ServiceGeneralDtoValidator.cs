using ErolAksoyResume.Dto.Concrete.ServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.ServiceDtoValidator
{
    public class ServiceGeneralDtoValidator : AbstractValidator<ServiceGeneralDto>
    {
        public ServiceGeneralDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title area cannot be null");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text area cannot be null");
            RuleFor(x => x.ImageUrl).MaximumLength(100).WithMessage("Image name maximum be 100 character");
        }
        
    }
}
