using System.Web.Http;
using Insurance.Model.Poco;
using Insurance.Models.Principal;

namespace Insurance.Controllers
{
    public class BaseApiController : ApiController
    {
        public readonly IAuthentication Auth;

        public BaseApiController(IAuthentication auth)
        {
            Auth = auth;
        }

        public Contact Contact => ((UserIndentity)Auth.CurrentUser.Identity).User;
    }
}
