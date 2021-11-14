using ERX.Questionnaire.Common.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Api.ModelValidators
{
    public class AddressApiRequestModelValidator : AbstractValidator<AddressApiRequestModel>
    {
        public AddressApiRequestModelValidator()
        {
            RuleFor(t => t.AddressLine1).NotNull().NotEmpty().WithMessage("Address Line 1 cannot be empty");
            RuleFor(t => t.Province).NotNull().NotEmpty().WithMessage("Province cannot be empty");
            RuleFor(t => t.District).NotNull().NotEmpty().WithMessage("District cannot be empty");
            RuleFor(t => t.Postcode).NotNull().NotEmpty().WithMessage("Postcode cannot be empty");
            RuleFor(t => t.City).NotNull().NotEmpty().WithMessage("City cannot be empty");
            RuleFor(t => t.Country).NotNull().NotEmpty().WithMessage("Country cannot be empty");
        }
    }
}
