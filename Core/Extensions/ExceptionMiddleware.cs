using Core.Entities.Concrete;
using Core.Extensions.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Security.JWT;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    //sarmallama
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        private ITokenHelper _tokenHelper;

        public ExceptionMiddleware(RequestDelegate next, ITokenHelper tokenHelper)
        {
            _next = next;
            _tokenHelper = tokenHelper;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                string authorizaControler = httpContext.Request.Path.Value.ToLower();
                if (authorizaControler.Contains("auth") || authorizaControler.Contains("swagger"))
                {
                    await _next(httpContext);
                }
                else
                {
                    await _next(httpContext);
                    string authHeader = httpContext.Request.Headers["Authorization"];
                    if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
                    {

                        if (_tokenHelper.AccessTokenExpirationControl(authHeader))
                        {
                            await _next(httpContext);
                        }
                        else
                        {
                            httpContext.Response.ContentType = "application/json";
                            httpContext.Response.StatusCode = StatusCodes.Status419AuthenticationTimeout;
                            await httpContext.Response.WriteAsync(new ErrorDetails
                            {
                                StatusCode = httpContext.Response.StatusCode, //bad request
                                Message = "User Authentication Timeout süresi dolmuştur."
                            }.ToString());
                        }

                    }
                    else
                    {
                        httpContext.Response.ContentType = "application/json";
                        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await httpContext.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = httpContext.Response.StatusCode, //bad request
                            Message = "User Authorize işlemi yapılmamış."
                        }.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //string message = "Internal Server Error";
            _ = e.Message;
            string message;
            object _errors = null;
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message.Replace("\r\n", " ");
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                List<ValidationErrorDto> validationErrors = new List<ValidationErrorDto>();
                foreach (var item in errors.ToList())
                {
                    validationErrors.Add(new ValidationErrorDto
                    {
                        ErrorCode = item.ErrorCode,
                        ErrorMessage = item.ErrorMessage,
                        PropertyName = item.PropertyName,
                        AttemptedValue = item.AttemptedValue

                    });
                    _errors = validationErrors;
                }
                await httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest,//bad request
                    Message = message,
                    ValidationError = validationErrors
                }.ToString());
            }
            else if (e.GetType() == typeof(ApplicationException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (e.GetType() == typeof(SecurityException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (e.GetType() == typeof(System.ArgumentNullException))
            {
                message = ExceptionMessage.JwtTokenIsNullOrEmpty;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (e.GetType() == typeof(System.ArgumentException))
            {
                message = ExceptionMessage.JwtTokenCanReadToken;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (e.GetType() == typeof(System.IO.DirectoryNotFoundException))
            {
                message = ExceptionMessage.DirectoryNotFoundException;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else
            {
                message = ExceptionMessage.InternalServerError;
            }

            //SecurityException

            await httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());

            //await httpContext.Response.WriteAsync(new ErrorDetails<object>(_errors, message).ToString());
        }
    }
}
