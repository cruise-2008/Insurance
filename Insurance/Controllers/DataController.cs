using System;
using System.Web.Http;
using Insurance.Models.Principal;

namespace Insurance.Controllers
{
    [System.Web.Mvc.Authorize]
    public class DataController : BaseApiController
    {
        public DataController(IAuthentication auth) : base(auth) { }

        [HttpPost]
        [System.Web.Mvc.Route("api/data/getdata")]
        public IHttpActionResult GetData()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}