using System.Web.Mvc;
using Insurance.Model.Interfaces;
using System;
using Insurance.Model.App.Osago;

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
        public JsonResult Index(bool eu)
        {
            OsagoData osagoEUplace = new OsagoData();
            osagoEUplace = _osagoService.GetOsagePlace(eu);
            return Json(osagoEUplace);
        }
   
        public ActionResult Compare()
        {
                ViewBag.BodyClass = "zakaz";
                return View();
        }
    }
}