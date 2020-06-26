using ErolAksoyResume.Dto.Concrete.ProfileDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.ProfileDtoValidator
{
    public class ProfileGeneralDtoValidator : AbstractValidator<ProfileGeneralDto>
    {
        public ProfileGeneralDtoValidator()
        {
            RuleFor(x => x.Phone).Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").WithMessage("Please Enter Valid Phone number ").MaximumLength(11).WithMessage("Phone number max length is 11 character !");
        }
    }
}
