using ERX.Questionnaire.Common.Entities;
using ERX.Questionnaire.Common.Enum;
using ERX.Questionnaire.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ERX.Questionnaire.UnitTest
{
    public class QuestionnaireTest
    {
        readonly IQuestionnaireService _questionnaireService;
        readonly IUserService _userService;

        public QuestionnaireTest(IQuestionnaireService questionnaireService, IUserService userService)
        {
            _questionnaireService = questionnaireService;
            _userService = userService;
        }

        [Theory]
        [InlineData(2)]
        public async Task GetApplicationStep_CheckCompletedApplication_Success(int userId)
        {
            var applicationStep = await _questionnaireService.GetApplicationStep(userId);
            Assert.Equal(applicationStep.ApplicationState.ToString(), ApplicationStatusEnum.Complete.ToString());
        }

        [Theory]
        [InlineData(12)]
        public async Task GetApplicationStep_CheckCompletedApplication_Error(int userId)
        {
            var applicationStep = await _questionnaireService.GetApplicationStep(userId);
            Assert.Equal(applicationStep.ApplicationState.ToString(), ApplicationStatusEnum.Complete.ToString());
        }

        [Theory]
        [InlineData(2)]
        public async Task GetDetailsQuestionResult_Success(int userId)
        {
            var questions = await _questionnaireService.GetDetailsQuestionResult(userId);
            Assert.NotNull(questions.PersonalInfo);
            Assert.NotNull(questions.HomeAddress);
            Assert.NotNull(questions.WorkAddress);
            Assert.NotNull(questions.WorkInfo);
        }

        [Theory]
        [InlineData(12)]
        public async Task GetDetailsQuestionResult_Error(int userId)
        {
            var questions = await _questionnaireService.GetDetailsQuestionResult(userId);
            Assert.Null(questions.PersonalInfo);
            Assert.Null(questions.HomeAddress);
            Assert.Null(questions.WorkAddress);
            Assert.Null(questions.WorkInfo);
        }

        [Fact]
        public async Task GetGroups_Success()
        {
            var questions = await _questionnaireService.GetGroups();
            Assert.NotNull(questions);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetQuestions_Success(short groupId)
        {
            var questions = await _questionnaireService.GetQuestions(groupId);
            Assert.NotNull(questions);
        }

        [Theory]
        [InlineData(4)]
        public async Task GetQuestions_Error(short groupId)
        {
            var questions = await _questionnaireService.GetQuestions(groupId);
            Assert.Null(questions);
        }

        [Fact]
        public async Task AddPersonalInfo_Success()
        {
            var newData = new AddPersonaInfoApiRequestModel
            {
                Title = "Mr",
                FirstName = "Rajeev",
                LastName = "Suresh",
                DateOfBirth = DateTime.Now.AddDays(-10000)
            };

            var result = await _userService.AddPersonalInfo(newData);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task AddAddress_Success()
        {
            var newData = new AddAddressApiRequestModel
            {
                UserId = 12,
                HomeAddress = new AddressApiRequestModel
                {
                    AddressLine1 = "Ashton Morph 38",
                    Province = "Bkk",
                    District = "bkk",
                    SubDistrict = "bkk",
                    City = "Bkk",
                    Postcode = "10110",
                    Country = "Thailand"
                },
                WorkAddress = new AddressApiRequestModel
                {
                    AddressLine1 = "Ashton Morph 38",
                    Province = "Bkk",
                    District = "bkk",
                    SubDistrict = "bkk",
                    City = "Bkk",
                    Postcode = "10110",
                    Country = "Thailand"
                }
            };

            var result = await _userService.AddAddress(newData);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task AddWorkInfo_Success()
        {
            var newData = new AddWorkInfoApiRequestModel
            {
                UserId = 12,
                OccupationId = 1,
                BusinessType = "IT",
                JobType = "Service"
            };

            var result = await _userService.AddWorkInfo(newData);

            Assert.True(result.IsValid);
        }
    }
}
