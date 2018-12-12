using System.Web.Mvc;
using Insurance.Model.Poco;
using Insurance.Models.Principal;
using Insurance.Models.ViewModel;

namespace Insurance.Controllers
{
    public class HeadController : Controller
    {
        public readonly IAuthentication Auth;

        public HeadController(IAuthentication auth)
        {
            Auth = auth;
        }

        public Contact Contact => ((UserIndentity) Auth.CurrentUser?.Identity)?.User;


        public ActionResult Index()
        {
            bool? ballanceClicked = false;
            var ballanceClickedValue = Session["BallanceClicked"];
            if (ballanceClickedValue != null) ballanceClicked = ballanceClickedValue as bool?;

            return PartialView("Head", new HeadViewModel {
                IsAuth = Contact != null,
                Phone = Contact == null ? string.Empty : Contact.Phone,
                BallanceClicked = ballanceClicked ?? false
            });
        }


        [HttpPost]
        public void BallanceClick()
        {
            Session["BallanceClicked"] = true;
        }
    }
}