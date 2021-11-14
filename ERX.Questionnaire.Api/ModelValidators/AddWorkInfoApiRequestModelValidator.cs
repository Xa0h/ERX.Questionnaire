using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Api.ModelValidators
{
    public class AddWorkInfoApiRequestModelValidator : AbstractValidator<AddWorkInfoApiRequestModel>
    {
        private IUserService _userService;

        public AddWorkInfoApiRequestModelValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(t => t.UserId).NotNull().NotEmpty().NotEqual(0).MustAsync(async (o, UserId, token) => await IsUserIdValid(UserId)).WithMessage("Invalid user id");
            RuleFor(t => t.OccupationId).NotNull().NotEmpty().WithMessage("Invalid occupation type");
            RuleFor(t => t.JobType).NotNull().NotEmpty().WithMessage("Invalid job type");
            RuleFor(t => t.BusinessType).NotNull().NotEmpty().WithMessage("Invalid business type");
        }

        public async Task<bool> IsUserIdValid(long userId)
        {
            return await _userService.IsUserIdValid(userId);
        }

    }
}
