using System;
using ERX.Questionnaire.Common.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERX.Questionnaire.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult OkV2<T>(T responseModel)
        {
            return Ok(new CommonApiResponseModel<T, ValidationResult>() { IsRequestSuccess = true, Response = responseModel });
        }
        protected IActionResult InternalServerErrorV2<T>(T responseModel, Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new CommonApiResponseModel<T, ValidationResult>() { IsRequestSuccess = false, Exceptions = ex.Message });
        }
    }
}
