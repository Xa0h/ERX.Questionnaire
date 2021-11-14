using ERX.Questionnaire.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.DataAccess.Interfaces
{
    public interface IQuestionnaireData
    {
        Task<List<QuestionnaireGroupsDataResponseModel>> GetGroups();
        Task<List<QuestionnaireDataResponseModel>> GetQuestions(int groupId);
        Task<bool> Add(string question, short groupId, int order);
        Task<bool> Edit(long questionId, string question, short groupId);
        Task<bool> Delete(long questionId);
        Task<PersonalInfoResponseModel> GetPersonalInfo(int userId);
        Task<AddressInfoResponseModel> GetHomeAddress(int userId);
        Task<AddressInfoResponseModel> GetWorkAddress(int userId);
        Task<WorkInfoResponseModel> GetWorkInfo(int userId);
        Task<List<QuestionnaireDetailedResponseModel>> GetQuestionnaireInfo(DateTime startDate, DateTime endDate);
    }
}
