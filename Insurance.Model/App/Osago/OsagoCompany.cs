using System;
using System.Collections.Generic;
using Insurance.Model.Poco;

namespace Insurance.Model.App.Osago
{
    public class OsagoCompany
    {
        public Guid PublicKey { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public double Commission { get; set; }
        public double Ktaxi { get; set; }
        public double Kprivileges { get; set; }
        public double K0 { get; set; }
        public double K1000 { get; set; }
        public double K2000 { get; set; }

        public List<OsagoPlace> Places { get; set; }


        public static explicit operator OsagoCompany(Company company)
        {
            return new OsagoCompany
            {
                PublicKey = company.PublicKey,
                Name = company.Name,
                Logo = company.Logo,
                Commission = company.Commission,
                Ktaxi = company.Ktaxi,
                Kprivileges = company.Kprivileges,
                K0 = company.K0,
                K1000 = company.K1000,
                K2000 = company.K2000,
                Places = new List<OsagoPlace>()
            };
        }
    }
}
