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
        public ActionResult GetEU(string eu)
        {
            if (eu == "on")
            {
                bool erp = true;
                var osagoEUplace = _osagoService.GetOsagePlace(erp);
            }
            return RedirectToAction("Index");
        }
   
        public ActionResult Compare()
        {
                ViewBag.BodyClass = "zakaz";
                return View();
        }
    }
}