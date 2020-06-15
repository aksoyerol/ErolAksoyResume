using ErolAksoyResume.Dto.Concrete.ResumeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.ValidationRules.FluentValidation.ResumeDtoValidator
{
    public class ResumeAddDtoValidator : AbstractValidator<ResumeAddDto>
    {
        public ResumeAddDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title area cannot be null !");
            RuleFor(x => x.Text).NotNull().WithMessage("Text area cannot be null !");
            //RuleFor(x => x.StartedDate).NotNull().WithMessage("Started Date area cannot be null !");
            //RuleFor(x => x.EndedDate).NotNull().WithMessage("Ended Date area cannot be null !");
            RuleFor(x=>x.SubCategoryId).NotNull().WithMessage("Sub Category area cannot be null !");
            RuleFor(x=>x.CategoryId).NotNull().WithMessage("Category area cannot be null !");
        }
    }
}
