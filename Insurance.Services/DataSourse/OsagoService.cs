using System.Linq;
using DapperExtensions;
using Insurance.Model.App.Osago;
using Insurance.Model.Interfaces;
using Insurance.Model.Poco;

namespace Insurance.Services.DataSourse
{
    public class OsagoService : BaseService, IOsagoService
    {
        public OsagoData GetOsagoData() {
            try {
                var result = new OsagoData();

                // Companies
                var companies = Connection.GetList<Company>(Predicates.Field<Company>(x => x.IsEnabled, Operator.Eq, true)).ToList();

                foreach (var company in companies) {
                    var osagoCompany = (OsagoCompany)company;

                    var places = Connection.GetList<Place>(Predicates.Field<Place>(x => x.CompanyId, Operator.Eq, company.Id)).ToList();
                    foreach (var place in places) {
                        osagoCompany.Places.Add((OsagoPlace)place);
                    }
                    result.Companies.Add(osagoCompany);
                }
                // Groups
                var groups = Connection.GetList<Group>().ToList();
                foreach (var group in groups) {
                    result.Groups.Add((OsagoGroup)group);
                }
                return result;
            }
            catch {
                return null;
            }
        }
    }
}