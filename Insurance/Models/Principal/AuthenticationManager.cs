using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Insurance.Model.Interfaces;
using Insurance.Model.Poco;

namespace Insurance.Models.Principal
{
    public class AuthenticationManager : IAuthentication
    {
        public AuthenticationManager(IContactService contactService)
        {
            _contactService = contactService;
        }

        private const string CookieName = "__AUTH_COOKIE";
        private readonly IContactService _contactService;
        private IPrincipal _currentUser;

        public HttpContext HttpContext
        {
            get { return HttpContext.Current; }
            set { HttpContext.Current = value; }
        }


        public IPrincipal CurrentUser {
            get {
                if (_currentUser != null) return _currentUser;

                var authCookie = HttpContext.Request.Cookies.Get(CookieName);
                if (!string.IsNullOrEmpty(authCookie?.Value)) {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket == null) return _currentUser;
                    _currentUser = new UserProvider(ticket.Name, this);
                }
                else {
                    _currentUser = null;
                }
                return _currentUser;
            }
        }


        public Contact Login(string phone)
        {
            var user = _contactService.Login(phone);
            if (user != null) CreateCookie(user.PublicKey.ToString());
            return user;
        }

        public Contact GetByPk(string pk)
        {
            return _contactService.GetByPublicKey(pk);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null) httpCookie.Value = string.Empty;
        }

        private void CreateCookie(string userName)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  true,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }
    }
}