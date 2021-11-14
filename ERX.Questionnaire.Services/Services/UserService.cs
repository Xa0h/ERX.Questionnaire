using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.DataAccess.Interfaces;
using ERX.Questionnaire.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Services.Services
{
    public class UserService : IUserService
    {
        readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }

        public async Task<List<CountryApiResponseModel>> GetCountryList()
        {
            List<CountryApiResponseModel> countryList = new List<CountryApiResponseModel>();

            var countries = await _userData.GetCountryList();

            if (countries != null && countries.Count() > 0)
            {
                countryList = countries.Select(t => new CountryApiResponseModel
                {
                    CountryId = t.CountryId,
                    CountryName = t.CountryName
                }).ToList();
            }

            return countryList;
        }

        public async Task<AddPersonalInfoApiResponseModel> AddPersonalInfo(AddPersonaInfoApiRequestModel apiRequest)
        {
            AddPersonalInfoApiResponseModel apiResponse = new AddPersonalInfoApiResponseModel();

            var country = await _userData.GetCountryById(apiRequest.CountryId);

            var newUser = await _userData.AddPersonalInfo(apiRequest, true);

            if (!newUser.HasValue)
            {
                apiResponse.Message = "An error occurred processing your request";
            }

            apiResponse.UserId = newUser.Value;
            apiResponse.IsValid = true;

            if (!country.IsSelectionPermitted)
            {
                apiResponse.Message = "Your application has been submitted successfully. Unfortunately we are not active in your country right now. Please check back later. Note down the User Id for future reference";
            }
            else
            {
                apiResponse.Message = "Personal Information submitted successfully";
            }

            return apiResponse;
        }

        public async Task<AddAddressApiResponseModel> AddAddress(AddAddressApiRequestModel apiRequest)
        {
            AddAddressApiResponseModel apiResponse = new AddAddressApiResponseModel();

            var isHomeAddressAdded = await _userData.AddHomeAddress(apiRequest.HomeAddress, apiRequest.UserId);

            if (!isHomeAddressAdded)
            {
                apiResponse.Message = "An error occurred processing your request";
            }

            var isWorkAddressAdded = await _userData.AddWorkAddress(apiRequest.WorkAddress, apiRequest.UserId);

            if (!isWorkAddressAdded)
            {
                apiResponse.Message = "An error occurred processing your request";
            }

            apiResponse.IsValid = true;
            apiResponse.Message = "Address Information added successfully";

            return apiResponse;
        }

        public async Task<AddWorkInfoApiResponseModel> AddWorkInfo(AddWorkInfoApiRequestModel apiRequest)
        {
            AddWorkInfoApiResponseModel apiResponse = new AddWorkInfoApiResponseModel();

            var isWorkInfoAdded = await _userData.AddWorkInfo(apiRequest);

            if (!isWorkInfoAdded)
            {
                apiResponse.Message = "An error occurred processing your request";
            }
            else
            {
                apiResponse.IsValid = true;
                apiResponse.Message = "Work Information added successfully";
            }

            return apiResponse;
        }

        public async Task<bool> IsUserIdValid(long userId)
        {
            return await _userData.IsUserIdValid(userId);
        }
    }
}
