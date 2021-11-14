using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Api.ModelValidators
{
    public class AddAddressApiRequestModelValidator : AbstractValidator<AddAddressApiRequestModel>
    {
        private IUserService _userService;
        public AddAddressApiRequestModelValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(t => t.UserId).NotNull().NotEmpty().NotEqual(0).MustAsync(async (o, UserId, token) => await IsUserIdValid(UserId)).WithMessage("Invalid user id");
        }

        public async Task<bool> IsUserIdValid(long userId)
        {
            return await _userService.IsUserIdValid(userId);
        }
    }
}
