using System.Web.Mvc;

namespace LegacyWebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content(string.Format("Welcome {0} !", HttpContext.User.Identity.Name));
        }
    }
}