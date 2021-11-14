using ClosedXML.Excel;
using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.DataAccess.Interfaces;
using ERX.Questionnaire.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Services.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        readonly IQuestionnaireData _questionData;
        public QuestionnaireService(IQuestionnaireData questionData)
        {
            _questionData = questionData;
        }

        public async Task<List<QuestionnaireGroupsDataResponseModel>> GetGroups()
        {
            return await _questionData.GetGroups();
        }

        public async Task<List<QuestionnaireDataResponseModel>> GetQuestions(int groupId)
        {
            return await _questionData.GetQuestions(groupId);
        }

        public async Task<AddQuestionApiResponseModel> Add(AddQuestionApiRequestModel apiRequest)
        {
            AddQuestionApiResponseModel apiResponse = new AddQuestionApiResponseModel();

            apiResponse.IsAdded = await _questionData.Add(apiRequest.Question, apiRequest.GroupId, apiRequest.OrderId);

            return apiResponse;
        }

        public async Task<EditQuestionApiResponseModel> Edit(EditQuestionApiRequestModel apiRequest)
        {
            EditQuestionApiResponseModel apiResponse = new EditQuestionApiResponseModel();

            apiResponse.IsEdited = await _questionData.Edit(apiRequest.QuestionId, apiRequest.Question, apiRequest.GroupId);

            return apiResponse;
        }

        public async Task<DeleteQuestionApiResponseModel> Delete(DeleteQuestionApiRequestModel apiRequest)
        {
            DeleteQuestionApiResponseModel apiResponse = new DeleteQuestionApiResponseModel();

            apiResponse.IsDeleted = await _questionData.Delete(apiRequest.QuestionId);

            return apiResponse;
        }

        public async Task<ApplicationStatusApiResponseModel> GetApplicationStep(int userId)
        {
            ApplicationStatusApiResponseModel apiResponse = new ApplicationStatusApiResponseModel();

            var personalInfo = await _questionData.GetPersonalInfo(userId);

            if (personalInfo == null)
            {
                apiResponse.ApplicationState = Common.Enum.ApplicationStatusEnum.PersonalInfo;
                return apiResponse;
            }

            if (personalInfo != null && !personalInfo.IsSelectionPermitted)
            {
                apiResponse.ApplicationState = Common.Enum.ApplicationStatusEnum.Complete;
                return apiResponse;
            }

            var homeAddress = await _questionData.GetHomeAddress(userId);

            var workAddress = await _questionData.GetWorkAddress(userId);

            if (homeAddress == null || workAddress == null)
            {
                apiResponse.ApplicationState = Common.Enum.ApplicationStatusEnum.Address;
                return apiResponse;
            }

            var workInfo = await _questionData.GetWorkInfo(userId);

            if (workInfo == null)
            {
                apiResponse.ApplicationState = Common.Enum.ApplicationStatusEnum.WorkInfo;
                return apiResponse;
            }

            apiResponse.ApplicationState = Common.Enum.ApplicationStatusEnum.Complete;
            return apiResponse;
        }

        public async Task<QuestionnaireDetailedResponseModel> GetDetailsQuestionResult(int userId)
        {
            QuestionnaireDetailedResponseModel apiResponse = new QuestionnaireDetailedResponseModel();

            apiResponse.PersonalInfo = await _questionData.GetPersonalInfo(userId);

            apiResponse.HomeAddress = await _questionData.GetHomeAddress(userId);

            apiResponse.WorkAddress = await _questionData.GetWorkAddress(userId);

            apiResponse.WorkInfo = await _questionData.GetWorkInfo(userId);


            return apiResponse;
        }

        public async Task<byte[]> DownloadQuestionnaire(DateTime startDate, DateTime endDate)
        {
            byte[] streamArray = null;

            List<QuestionnaireDetailedResponseModel> apiResponse = new List<QuestionnaireDetailedResponseModel>();

            apiResponse = await _questionData.GetQuestionnaireInfo(startDate, endDate);


            if (apiResponse != null && apiResponse.Count > 0)
            {
                DataTable dt = new DataTable("Grid");

                dt.Columns.AddRange(new DataColumn[21] { new DataColumn("Title"),
                                        new DataColumn("FirstName"),
                                        new DataColumn("LastName"),
                                        new DataColumn("DateOfBirth"),
                                        new DataColumn("HomeCountry"),
                                        new DataColumn("HomeAddressLine1"),
                                        new DataColumn("HomePostcode"),
                                        new DataColumn("HomeProvince"),
                                        new DataColumn("HomeDistrict"),
                                        new DataColumn("HomeSubDistrict"),
                                        new DataColumn("HomeCity"),
                                        new DataColumn("WorkCountry"),
                                        new DataColumn("WorkAddressLine1"),
                                        new DataColumn("WorkPostcode"),
                                        new DataColumn("WorkProvince"),
                                        new DataColumn("WorkDistrict"),
                                        new DataColumn("WorkSubDistrict"),
                                        new DataColumn("WorkCity"),
                                        new DataColumn("OccupationType"),
                                        new DataColumn("JobType"),
                                        new DataColumn("BusinessType")
            });

                foreach (var item in apiResponse)
                {
                    dt.Rows.Add(item.PersonalInfo.Title,
                                item.PersonalInfo.FirstName,
                                item.PersonalInfo.LastName,
                                item.PersonalInfo.DateOfBirth,
                                item.HomeAddress != null ? item.HomeAddress.Country : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.AddressLine1 : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.City : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.Province : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.District : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.SubDistrict : string.Empty,
                                item.HomeAddress != null ? item.HomeAddress.Postcode : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.Country : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.AddressLine1 : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.City : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.Province : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.District : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.SubDistrict : string.Empty,
                                item.WorkAddress != null ? item.WorkAddress.Postcode : string.Empty,
                                item.WorkInfo != null ? item.WorkInfo.OccupationType : string.Empty,
                                item.WorkInfo != null ? item.WorkInfo.JobType : string.Empty,
                                item.WorkInfo != null ? item.WorkInfo.BusinessType : string.Empty);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        streamArray = stream.ToArray();
                    }
                }

            }

            return streamArray;
        }
    }
}
