using CopaDeEquipes.App.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CopaDeEquipes.App.Filters
{
    public class ApiExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            if (context.Exception is ArgumentException)
            {                
                var ex = context.Exception as ArgumentException;
                context.Exception = null;
                apiError = new ApiError(ex.Message);                

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }            
            else
            {
                var msg = "Erro nao esperado, entre em Contato com o Administrador Do Sistema";
                string stack = context.Exception.StackTrace;

                apiError = new ApiError(msg);
                apiError.detail = stack;

                context.HttpContext.Response.StatusCode = 500;                
            }            

            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}
