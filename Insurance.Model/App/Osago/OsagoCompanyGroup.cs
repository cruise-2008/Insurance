using Insurance.Model.Poco;

namespace Insurance.Model.App.Osago
{
    public class OsagoCompanyGroup
    {
        public int GroupId { get; set; }
        public double K { get; set; }


        public static explicit operator OsagoCompanyGroup(CompanyGroup companyGroup)
        {
            return new OsagoCompanyGroup
            {
                GroupId = companyGroup.GroupId,
                K = companyGroup.K,
            };
        }
    }
}
