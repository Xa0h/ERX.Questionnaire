using ERX.Questionnaire.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.DataAccess.Interfaces
{
    public interface IUserData
    {
        Task<List<CountryResponseModel>> GetCountryList();
        Task<CountryResponseModel> GetCountryById(int countryId);
        Task<long?> AddPersonalInfo(AddPersonaInfoApiRequestModel apiRequest, bool isActive);
        Task<bool> AddHomeAddress(AddressApiRequestModel apiRequest, long userId);
        Task<bool> AddWorkAddress(AddressApiRequestModel apiRequest, long userId);
        Task<bool> AddWorkInfo(AddWorkInfoApiRequestModel apiRequest);
        Task<bool> IsUserIdValid(long userId);
    }
}
