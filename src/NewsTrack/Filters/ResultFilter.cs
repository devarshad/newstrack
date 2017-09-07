using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsTrack.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result;
            var viewResult = result as ViewResult;
            if (viewResult != null)
            {
                // if the controller action returned a view result
                // and the someValue parameter equals foo we replace the 
                // view result initially returned by the action by a 
                // partial view result
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var partialResult = new PartialViewResult();
                    partialResult.ViewData.Model = viewResult.Model;
                    filterContext.Result = partialResult;
                }
            }
        }
    }
}