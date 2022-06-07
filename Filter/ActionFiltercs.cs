using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace UpsoApi.Filter
{
    public class ActionFiltercs : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            JsonResult jsonRespon = filterContext.Result as JsonResult;
            if (jsonRespon == null)
                return;

            jsonRespon.Value = new { result = true, data = jsonRespon.Value };
        }
    }
}
