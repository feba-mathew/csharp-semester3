
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
       
        public ActionResult Error()
        {
            return View();
        }
    }
}