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

      //  [HttpPost]
        public JsonResult CalculateCoefficient(bool isEU, bool isTaxi, bool isPrivilege, string placeId, int groupK)
        {
            var k = _osagoService.GetOsageCoefficient(isEU, isTaxi, isPrivilege, placeId, groupK);
        
            return Json(new {  data = k }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Compare()
        {
                ViewBag.BodyClass = "zakaz";
                return View();
        }
    }
}