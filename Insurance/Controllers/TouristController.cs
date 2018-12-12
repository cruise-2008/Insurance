using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class TouristController : Controller
    {
        // GET: Tourist
        public ActionResult Index()
        {
            ViewBag.BodyClass = "osago";
            return View();
        }
    }
}