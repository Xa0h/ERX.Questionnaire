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
    public class UserController : BaseApiController
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("v1/Country/Get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountry()
        {
            List<CountryApiResponseModel> apiResponse = new List<CountryApiResponseModel>();

            try
            {
                apiResponse = await _userService.GetCountryList();
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/AddPersonalInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPersonalInfo(AddPersonaInfoApiRequestModel apiRequest)
        {
            AddPersonalInfoApiResponseModel apiResponse = new AddPersonalInfoApiResponseModel();

            try
            {
                apiResponse = await _userService.AddPersonalInfo(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/AddAddress")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAddress(AddAddressApiRequestModel apiRequest)
        {
            AddAddressApiResponseModel apiResponse = new AddAddressApiResponseModel();

            try
            {
                apiResponse = await _userService.AddAddress(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }

        [HttpPost]
        [Route("v1/AddWorkInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> AddWorkInfo(AddWorkInfoApiRequestModel apiRequest)
        {
            AddWorkInfoApiResponseModel apiResponse = new AddWorkInfoApiResponseModel();

            try
            {
                apiResponse = await _userService.AddWorkInfo(apiRequest);
                return OkV2(apiResponse);
            }
            catch (Exception ex)
            {
                return InternalServerErrorV2(apiResponse, ex);
            }
        }
    }
}
