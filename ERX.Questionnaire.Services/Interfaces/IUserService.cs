using ERX.Questionnaire.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<CountryApiResponseModel>> GetCountryList();
        Task<AddPersonalInfoApiResponseModel> AddPersonalInfo(AddPersonaInfoApiRequestModel apiRequest);
        Task<AddAddressApiResponseModel> AddAddress(AddAddressApiRequestModel apiRequest);
        Task<AddWorkInfoApiResponseModel> AddWorkInfo(AddWorkInfoApiRequestModel apiRequest);
        Task<bool> IsUserIdValid(long userId);
    }
}
