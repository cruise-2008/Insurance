using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class PoliceCheckController : Controller
    {
        // GET: PoliceCheck
        public ActionResult Index()
        {
            ViewBag.BodyClass = "Proverka";
            return View();
        }
    }
}