using System.Collections.Generic;

namespace Insurance.Model.App.Osago
{
    public class OsagoData
    {
        public List<OsagoCompany> Companies { get; set; }
        public List<OsagoGroup> Groups { get; set; }
        public List<OsagoPlace> Places { get; set; }

        public OsagoData()
        {
            Companies = new List<OsagoCompany>();
            Groups = new List<OsagoGroup>();
            Places = new List<OsagoPlace>();
        }
    }
}
