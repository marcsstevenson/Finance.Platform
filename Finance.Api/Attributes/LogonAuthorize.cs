using System.Web.Mvc;

namespace Finance.Api.Attributes
{
    /// <summary>
    /// Authorize controller methods except if the controller is decorated with AllowAnonymous;
    /// Based on code from http://blogs.msdn.com/b/rickandy/archive/2011/05/02/securing-your-asp-net-mvc-3-application.aspx
    /// </summary>
    public class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)))
            {
                base.OnAuthorization(filterContext);
            }
        }

        private class Http401Result : ActionResult
        {
            public override void ExecuteResult(ControllerContext context)
            {
                // Set the response code to 401.
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.Write("You have been logged out. Log back in to continue.");
                context.HttpContext.Response.End();
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                //Ajax request doesn't return to login page, it just returns 401 error.
                filterContext.Result = new Http401Result();
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
