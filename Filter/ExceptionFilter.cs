using System;
using System.Net;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace UpsoApi.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        #region Overrides of ExceptionFilterAttribute

        public override void OnException(ExceptionContext context)
        {
            var actionDescriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            Type controllerType = actionDescriptor.ControllerTypeInfo;

            var controllerBase = typeof(ControllerBase);
            var controller = typeof(Controller);

            if (controllerType.IsSubclassOf(controllerBase) && !controllerType.IsSubclassOf(controller))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = SetJson(context.HttpContext.Response.StatusCode, context.Exception.Message);
            }

            // Pages implements ControllerBase and Controller
            //if (controllerType.IsSubclassOf(controllerBase) && controllerType.IsSubclassOf(controller))
            //{
            //    // Handle page exception
            //}
            base.OnException(context);
        }

        /// <summary>
        /// Jsondata 설정
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private JsonResult SetJson(int StatusCode, string message) 
        {
            var jsonResult = new {
                result = false,
                code = StatusCode,
                data = message
            };
            return new JsonResult(jsonResult);
        }

        #endregion
    }
}
