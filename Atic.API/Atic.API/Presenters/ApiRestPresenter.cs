using Atic.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Atic.API.Presenters
{
    public class ApiRestPresenter : IApiRestPresenter
    {
        public IActionResult CreatedAtActionResult<T>(ApiResponse<T> result) where T : class
        {
            return result.Invalid ? BaseErrorResult(result)
                : new JsonResult(result.Content) { StatusCode = (int)HttpStatusCode.Created };
        }

        public IActionResult CustomStatusCodeResult<T>(ApiResponse<T> result, HttpStatusCode statusCode) where T : class
        {
            return result.Invalid ? BaseErrorResult(result, statusCode)
                : new JsonResult(result.Content) { StatusCode = (int)statusCode };
        }

        public IActionResult GetActionResult<T>(ApiResponse<T> result) where T : class
        {
            return result.Invalid ? BaseErrorResult(result, result.StatusCode)
                : new JsonResult(result.Content) { StatusCode = (int)HttpStatusCode.OK };
        }

        private IActionResult BaseErrorResult<T>(ApiResponse<T> result, HttpStatusCode statusCode = HttpStatusCode.BadRequest) where T : class
        {
            return new JsonResult(result.Notifications) { StatusCode = (int)statusCode };
        }
    }
}
