using ERX.Questionnaire.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Services.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<List<QuestionnaireGroupsDataResponseModel>> GetGroups();
        Task<List<QuestionnaireDataResponseModel>> GetQuestions(int groupId);
        Task<AddQuestionApiResponseModel> Add(AddQuestionApiRequestModel apiRequest);
        Task<EditQuestionApiResponseModel> Edit(EditQuestionApiRequestModel apiRequest);
        Task<DeleteQuestionApiResponseModel> Delete(DeleteQuestionApiRequestModel apiRequest);
        Task<ApplicationStatusApiResponseModel> GetApplicationStep(int userId);
        Task<QuestionnaireDetailedResponseModel> GetDetailsQuestionResult(int userId);
        Task<byte[]> DownloadQuestionnaire(DateTime startDate, DateTime endDate);
    }
}
