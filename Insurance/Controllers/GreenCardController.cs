using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class GreenCardController : Controller
    {
        // GET: GreenCard
        public ActionResult Index()
        {
            ViewBag.BodyClass = "osago";
            return View();
        }
    }
}