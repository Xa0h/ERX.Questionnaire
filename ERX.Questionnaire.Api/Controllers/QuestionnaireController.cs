using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERX.Questionnaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : BaseApiController
    {
        readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpGet]
        [Route("v1/GetGroups")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGroups()
        {
            List<QuestionnaireGroupsDataResponseModel> apiResponse = new List<QuestionnaireGroupsDataResponseModel>();

            try
            {
                apiResponse = await _questionnaireService.GetGroups();
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpGet]
        [Route("v1/GetQuestions")]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestions(int groupId)
        {
            List<QuestionnaireDataResponseModel> apiResponse = new List<QuestionnaireDataResponseModel>();

            try
            {
                apiResponse = await _questionnaireService.GetQuestions(groupId);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/AddQuestion")]
        [AllowAnonymous]
        public async Task<IActionResult> AddQuestion(AddQuestionApiRequestModel apiRequest)
        {
            AddQuestionApiResponseModel apiResponse = new AddQuestionApiResponseModel();

            try
            {
                apiResponse = await _questionnaireService.Add(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/EditQuestion")]
        [AllowAnonymous]
        public async Task<IActionResult> EditQuestion(EditQuestionApiRequestModel apiRequest)
        {
            EditQuestionApiResponseModel apiResponse = new EditQuestionApiResponseModel();

            try
            {
                apiResponse = await _questionnaireService.Edit(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/DeleteQuestion")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteQuestion(DeleteQuestionApiRequestModel apiRequest)
        {
            DeleteQuestionApiResponseModel apiResponse = new DeleteQuestionApiResponseModel();

            try
            {
                apiResponse = await _questionnaireService.Delete(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpGet]
        [Route("v1/GetApplicationStatus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetApplicationStep(int userId)
        {
            ApplicationStatusApiResponseModel apiResponse = new ApplicationStatusApiResponseModel();

            try
            {
                apiResponse = await _questionnaireService.GetApplicationStep(userId);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpGet]
        [Route("v1/GetQuestionnaireByUserId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetQuestionnaireByUserId(int userId)
        {
            QuestionnaireDetailedResponseModel apiResponse = new QuestionnaireDetailedResponseModel();

            try
            {
                apiResponse = await _questionnaireService.GetDetailsQuestionResult(userId);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpGet]
        [Route("v1/DownloadQuestionnaireReport")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadQuestionnaireReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                byte[] excelStream = await _questionnaireService.DownloadQuestionnaire(startDate, endDate);
                return File(excelStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2("Error", ex);
            }
        }
    }
}
