
using System.Web;
using System.Web.Mvc;

namespace HelloWorld
{
    public class AuthorizeIPAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentrequest = HttpContext.Current.Request;
            //var currentrequest = filterContext.HttpContext.Request;

            var clientIPAddress = currentrequest.UserHostAddress;
            if(clientIPAddress == "::1" || clientIPAddress == "127.0.0.1")
            {
                filterContext.Result = new HttpStatusCodeResult
                    (System.Net.HttpStatusCode.Forbidden);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}