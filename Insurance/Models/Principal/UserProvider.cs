using System.Security.Principal;

namespace Insurance.Models.Principal
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity UserIdentity { get; }

        public IIdentity Identity => UserIdentity;

        public bool IsInRole(string role)
        {
            if (UserIdentity.User == null)
            {
                return false;
            }
            return true;
        }

        public UserProvider(string pk, IAuthentication auth)
        {
            UserIdentity = new UserIndentity();
            UserIdentity.Init(pk, auth);
        }

        public override string ToString() {
            return UserIdentity.Name;
        }
    }
}