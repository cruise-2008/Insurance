using System.Web.Mvc;
using Insurance.Model.Interfaces;
using System;

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

        [HttpPost]
        public ActionResult Compare(string comparison)
        {
            if (!String.IsNullOrWhiteSpace(comparison))
            {
                ViewBag.BodyClass = "zakaz";
                return View();
            }
            TempData["Message"] = "Enter the place of registration of the vehicle";
            return RedirectToAction("Index");

        }
    }
}