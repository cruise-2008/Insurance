using System;
using System.Web.Http;
using Insurance.Models.Api;
using Insurance.Models.Principal;

namespace Insurance.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IAuthentication auth) : base(auth) { }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/account/login")]
        public IHttpActionResult Login(LoginRequest model) {
            try {
                if (!ModelState.IsValid) return BadRequest();
                var contact = Auth.Login(model.Phone);
                if (contact == null) return Unauthorized();
                return Ok();
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/account/logout")]
        public IHttpActionResult Logout() {
            try {
                Auth.LogOut();
                return Ok();
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }
    }
}