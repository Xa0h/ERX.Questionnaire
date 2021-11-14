using ERX.Questionnaire.Common.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Api.ModelValidators
{
    public class AddPersonalInfoApiRequestModelValidator : AbstractValidator<AddPersonaInfoApiRequestModel>
    {
        public AddPersonalInfoApiRequestModelValidator()
        {
            RuleFor(t => t.Title).NotNull().NotEmpty().WithMessage("Province cannot be empty");
            RuleFor(t => t.FirstName).NotNull().NotEmpty().WithMessage("District cannot be empty");
            RuleFor(t => t.LastName).NotNull().NotEmpty().WithMessage("Postcode cannot be empty");
            RuleFor(t => t.DateOfBirth).NotNull().NotEmpty().WithMessage("Date of birth cannot be empty");
            RuleFor(t => t.CountryId).NotNull().NotEmpty().WithMessage("Country Id cannot be empty");
        }
    }
}
