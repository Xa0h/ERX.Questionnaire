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
    public class QuestionnaireData : IQuestionnaireData
    {
        public async Task<List<QuestionnaireGroupsDataResponseModel>> GetGroups()
        {
            using (var _context = new ERXContext())
            {
                return await _context.QuestionnaireGroups.Where(t => t.IsActive == true).Select(t => new QuestionnaireGroupsDataResponseModel
                {
                    GroupId = t.GroupId,
                    GroupName = t.GroupName
                }).ToListAsync();
            }
        }

        public async Task<List<QuestionnaireDataResponseModel>> GetQuestions(int groupId)
        {
            using (var _context = new ERXContext())
            {
                return await _context.Questionnaires.Where(t => t.IsActive == true && t.GroupId == groupId).OrderBy(t => t.Order).Select(t => new QuestionnaireDataResponseModel
                {
                    QuestionId = t.QuestionnaireId,
                    Question = t.Question,
                    OrderId = t.Order
                }).ToListAsync();
            }
        }

        public async Task<bool> Add(string question, short groupId, int order)
        {
            bool isAdded = false;

            using (var _context = new ERXContext())
            {
                Database.Models.Questionnaire newQuestion = new Database.Models.Questionnaire()
                {
                    GroupId = groupId,
                    IsActive = true,
                    Order = order,
                    Question = question,
                    CreatedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now
                };
                _context.Questionnaires.Add(newQuestion);
                var cnt = await _context.SaveChangesAsync();

                if (cnt > 0)
                {
                    isAdded = true;
                }
            }

            return isAdded;
        }

        public async Task<bool> Edit(long questionId, string question, short groupId)
        {
            bool isEdited = false;

            using (var _context = new ERXContext())
            {
                var editQuestion = await _context.Questionnaires.Where(t => t.QuestionnaireId == questionId).FirstOrDefaultAsync();

                if (editQuestion != null)
                {
                    editQuestion.Question = question;
                    editQuestion.GroupId = groupId;

                    var cnt = await _context.SaveChangesAsync();

                    if (cnt > 0)
                    {
                        isEdited = true;
                    }
                }
            }

            return isEdited;
        }

        public async Task<bool> Delete(long questionId)
        {
            bool isDeleted = false;

            using (var _context = new ERXContext())
            {
                var deleteQuestion = await _context.Questionnaires.Where(t => t.QuestionnaireId == questionId).FirstOrDefaultAsync();

                if (deleteQuestion != null)
                {
                    deleteQuestion.IsActive = false;

                    var cnt = await _context.SaveChangesAsync();

                    if (cnt > 0)
                    {
                        isDeleted = true;
                    }
                }
            }

            return isDeleted;
        }

        public async Task<PersonalInfoResponseModel> GetPersonalInfo(int userId)
        {
            using(var _context = new ERXContext())
            {
                return await (from a in _context.PersonalInfos
                              join b in _context.Countries on a.CountryId equals b.CountryId
                              where a.UserId == userId
                              select new PersonalInfoResponseModel
                              {
                                  Title = a.Title,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  DateOfBirth = a.DateOfBirth,
                                  Country = b.CountryName,
                                  IsSelectionPermitted = b.IsSelectionPermitted
                              }).FirstOrDefaultAsync();
            }
        }

        public async Task<AddressInfoResponseModel> GetHomeAddress(int userId)
        {
            using(var _context = new ERXContext())
            {
                return await _context.HomeAddresses.Where(t => t.UserId == userId).Select(t => new AddressInfoResponseModel
                {
                    AddressLine1 = t.AddressLine1,
                    Country  = t.Country,
                    City = t.City,
                    District = t.District,
                    Province = t.Province,
                    Postcode = t.Postcode,
                    SubDistrict = t.SubDistrict
                }).FirstOrDefaultAsync();
            }
        }

        public async Task<AddressInfoResponseModel> GetWorkAddress(int userId)
        {
            using (var _context = new ERXContext())
            {
                return await _context.WorkAddresses.Where(t => t.UserId == userId).Select(t => new AddressInfoResponseModel
                {
                    AddressLine1 = t.AddressLine1,
                    Country = t.Country,
                    City = t.City,
                    District = t.District,
                    Province = t.Province,
                    Postcode = t.Postcode,
                    SubDistrict = t.SubDistrict
                }).FirstOrDefaultAsync();
            }
        }

        public async Task<WorkInfoResponseModel> GetWorkInfo(int userId)
        {
            using(var _context = new ERXContext())
            {
                return await (from a in _context.WorkInfos
                              join b in _context.Occupations on a.OccupationId equals b.OccupationId
                              where a.UserId == userId
                              select new WorkInfoResponseModel
                              {
                                  OccupationType = b.OccupationType,
                                  BusinessType = a.BusinessType,
                                  JobType = a.JobType
                              }).FirstOrDefaultAsync();
            }
        }

        public async Task<List<QuestionnaireDetailedResponseModel>> GetQuestionnaireInfo(DateTime startDate, DateTime endDate)
        {
            using(var _context = new ERXContext())
            {
                return await (from a in _context.PersonalInfos
                              join b in _context.HomeAddresses on a.UserId equals b.UserId into t
                              from t2 in t.DefaultIfEmpty()
                              join c in _context.WorkAddresses on a.UserId equals c.UserId into t3
                              from t4 in t3.DefaultIfEmpty()
                              join d in _context.WorkInfos on a.UserId equals d.UserId into t5
                              from t6 in t5.DefaultIfEmpty()
                              join e in _context.Countries on a.CountryId equals e.CountryId
                              where a.CreatedOn >= startDate && a.CreatedOn <= endDate
                              select new QuestionnaireDetailedResponseModel
                              {
                                  PersonalInfo = new PersonalInfoResponseModel
                                  {
                                      Title = a.Title,
                                      FirstName = a.FirstName,
                                      LastName = a.LastName,
                                      DateOfBirth = a.DateOfBirth,
                                      Country = e.CountryName
                                  },
                                  HomeAddress = t2 != null ? new AddressInfoResponseModel
                                  {
                                      AddressLine1 = t2.AddressLine1,
                                      Country = t2.Country,
                                      City = t2.City,
                                      Postcode = t2.Postcode,
                                      Province = t2.Province,
                                      District = t2.District,
                                      SubDistrict = t2.SubDistrict                                      
                                  } : null,
                                  WorkAddress = t4 != null ? new AddressInfoResponseModel
                                  {
                                      AddressLine1 = t4.AddressLine1,
                                      Country = t4.Country,
                                      City = t4.City,
                                      Postcode = t4.Postcode,
                                      Province = t4.Province,
                                      District = t4.District,
                                      SubDistrict = t4.SubDistrict
                                  } : null,
                                  WorkInfo = t6 != null ? new WorkInfoResponseModel
                                  {
                                      JobType = t6.JobType,
                                      BusinessType = t6.BusinessType
                                  } : null
                              }).ToListAsync();
            }
        }
    }
}
