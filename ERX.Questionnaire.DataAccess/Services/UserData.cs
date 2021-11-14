using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.DataAccess.Interfaces;
using ERX.Questionnaire.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.DataAccess.Services
{
    public class UserData : IUserData
    {
        public async Task<List<CountryResponseModel>> GetCountryList()
        {
            using (var _context = new ERXContext())
            {
                return (await _context.Countries.Where(t => t.IsActive == true).Select(t => new CountryResponseModel
                {
                    CountryId = t.CountryId,
                    CountryName = t.CountryName,
                    IsSelectionPermitted = t.IsSelectionPermitted
                }).ToListAsync());
            }
        }

        public async Task<CountryResponseModel> GetCountryById(int countryId)
        {
            using (var _context = new ERXContext())
            {
                return (await _context.Countries.Where(t => t.IsActive == true && t.CountryId == countryId).Select(t => new CountryResponseModel
                {
                    CountryId = t.CountryId,
                    CountryName = t.CountryName,
                    IsSelectionPermitted = t.IsSelectionPermitted
                }).FirstOrDefaultAsync());
            }
        }

        public async Task<long?> AddPersonalInfo(AddPersonaInfoApiRequestModel apiRequest, bool isActive)
        {
            long? userId = null;

            using (var _context = new ERXContext())
            {
                PersonalInfo newInfo = new PersonalInfo()
                {
                    Title = apiRequest.Title,
                    FirstName = apiRequest.FirstName,
                    LastName = apiRequest.LastName,
                    DateOfBirth = apiRequest.DateOfBirth,
                    CountryId = apiRequest.CountryId,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                };

                _context.PersonalInfos.Add(newInfo);
                var cnt = await _context.SaveChangesAsync();

                if (cnt > 0)
                {
                    userId = newInfo.UserId;
                }
            }

            return userId;
        }

        public async Task<bool> AddHomeAddress(AddressApiRequestModel apiRequest, long userId)
        {
            bool isValid = false;

            using(var _context = new ERXContext())
            {
                var homeAddress = new HomeAddress
                {
                    UserId = userId,
                    AddressLine1 = apiRequest.AddressLine1,
                    Province = apiRequest.Province,
                    District = apiRequest.District,
                    SubDistrict = apiRequest.SubDistrict,
                    City = apiRequest.City,
                    Country = apiRequest.Country,
                    Postcode = apiRequest.Postcode,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                };

                _context.HomeAddresses.Add(homeAddress);
                var cnt = await _context.SaveChangesAsync();

                if(cnt > 0)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public async Task<bool> AddWorkAddress(AddressApiRequestModel apiRequest, long userId)
        {
            bool isValid = false;

            using (var _context = new ERXContext())
            {
                var workAddress = new WorkAddress
                {
                    UserId = userId,
                    AddressLine1 = apiRequest.AddressLine1,
                    Province = apiRequest.Province,
                    District = apiRequest.District,
                    SubDistrict = apiRequest.SubDistrict,
                    City = apiRequest.City,
                    Country = apiRequest.Country,
                    Postcode = apiRequest.Postcode,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                };

                _context.WorkAddresses.Add(workAddress);
                var cnt = await _context.SaveChangesAsync();

                if (cnt > 0)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public async Task<bool> AddWorkInfo(AddWorkInfoApiRequestModel apiRequest)
        {
            bool isValid = false;

            using (var _context = new ERXContext())
            {
                var workInfo = new WorkInfo
                {
                    BusinessType = apiRequest.BusinessType,
                    OccupationId = apiRequest.OccupationId,
                    JobType = apiRequest.JobType,
                    IsActive = true,
                    UserId = apiRequest.UserId,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                };

                _context.WorkInfos.Add(workInfo);
                var cnt = await _context.SaveChangesAsync();

                if(cnt > 0)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public async Task<bool> IsUserIdValid(long userId)
        {
            using(var _context = new ERXContext())
            {
                return await _context.PersonalInfos.AnyAsync(t => t.UserId == userId);
            }
        }
    }
}
