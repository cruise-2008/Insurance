using System.Security.Principal;
using Insurance.Model.Poco;

namespace Insurance.Models.Principal
{
    public class UserIndentity : IIdentity
    {
        public Contact User { get; set; }

        public string AuthenticationType => typeof(Contact).ToString();

        public bool IsAuthenticated => User != null;

        public string Name => User?.PublicKey.ToString();

        public void Init(string pk, IAuthentication auth)
        {
            if (!string.IsNullOrEmpty(pk))
            {
                User = auth.GetByPk(pk);
            }
        }
    }
}