using Insurance.Model.App.Enum;
using Insurance.Model.Poco;

namespace Insurance.Model.Interfaces
{
    public interface IContactService
    {
        Contact Login(string phone);
        Contact GetByPublicKey(string pk);
        bool IsInRole(string pk, AppRole role);
    }
}
