using System.Web;
using System.Web.Mvc;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Filters
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login?RedirectUrl=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }
        }
    }
}