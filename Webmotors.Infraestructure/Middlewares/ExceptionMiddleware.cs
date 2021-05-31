using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Webmotors.Infraestructure.ApiModels;

namespace Webmotors.Infraestructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ResponseError();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is ValidationException)
            {
                var exceptionCasted = (ValidationException)exception;
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

                foreach (var error in exceptionCasted.Errors)
                    response.Errors.Add(new Error(error.ErrorMessage));

                if (response.Errors.Count == 0 && !string.IsNullOrEmpty(exceptionCasted.Message))
                    response.Errors.Add(new Error(exceptionCasted.Message));
            }
            else
            {
                response.Errors.Add(new Error("Ocorreu um erro, por favor tente mais tarde."));
            }

            return context.Response.WriteAsync(response.ToString());
        }
    }
}
