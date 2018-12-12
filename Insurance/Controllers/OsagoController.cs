using System.Web.Mvc;
using Insurance.Model.Interfaces;

namespace Insurance.Controllers
{
    public class OsagoController : Controller
    {
        private readonly IOsagoService _osagoService;

        public OsagoController(IOsagoService osagoService)
        {
            _osagoService = osagoService;
        }

        // GET: Osago
        public ActionResult Index()
        {
            ViewBag.BodyClass = "osago";
            var osagoCompanies = _osagoService.GetOsagoData();
            return View(osagoCompanies);
        }

        public ActionResult Compare()
        {
            ViewBag.BodyClass = "zakaz";
            return View();
        }
    }
}