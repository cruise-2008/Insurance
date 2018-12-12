using System.Security.Principal;
using System.Web;
using Insurance.Model.Poco;

namespace Insurance.Models.Principal
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        IPrincipal CurrentUser { get; }
        Contact Login(string phone);
        Contact GetByPk(string pk);
        void LogOut();
    }
}