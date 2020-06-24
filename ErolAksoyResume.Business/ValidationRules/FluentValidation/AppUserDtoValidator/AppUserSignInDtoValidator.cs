using ErolAksoyResume.Dto.Concrete.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.AppUserDtoValidator
{
    public class AppUserSignInDtoValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cannot be null !");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5).WithMessage("Password cannot be null and minimum character length must be 5");
        }
    }
}
