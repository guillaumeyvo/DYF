using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYF
{
    public class CustomAttribute
    {
        public class TrackUrlDetails : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                ViewResultBase view = filterContext.Result as ViewResultBase;
                string controllerName = filterContext.RequestContext.RouteData.Values["controller"].ToString();
                string viewName = filterContext.RequestContext.RouteData.Values["action"].ToString();
                if (view != null)
                {
                    //viewName = view.ViewName;
                    //controllerName = filterContext.Controller.ToString();

                    //// If we did not explicitly specify the view name in View() method,
                    //// it will be same as the action name. So let's get that.
                    //if (String.IsNullOrEmpty(viewName))
                    //{
                    //    viewName = filterContext.ActionDescriptor.ActionName;
                    //    controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ToString();
                    //}
                    view.ViewBag.CurrentController = controllerName;
                    view.ViewBag.CurrentView = viewName;
                }
            }
        }
    }
}