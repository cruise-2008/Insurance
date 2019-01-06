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
                var osagoData = new OsagoData {
                    Bp = Connection.GetList<Settings>().First().Bp
                };

                // Groups
                var commonGroups = Connection.GetList<Group>().ToList();
                foreach (var group in commonGroups) {
                    osagoData.Groups.Add((OsagoGroup)group);
                }

                // Companies
                var companies = Connection.GetList<Company>(Predicates.Field<Company>(x => x.IsEnabled, Operator.Eq, true)).ToList();

                foreach (var company in companies) {
                    var osagoCompany = (OsagoCompany)company;

                    osagoCompany.PlaceDefault = Connection.GetList<PlaceDefault>(Predicates.Field<PlaceDefault>(x => x.CompanyId, Operator.Eq, company.Id)).First().K;
                    osagoCompany.PlaceEu = Connection.GetList<PlaceEu>(Predicates.Field<PlaceEu>(x => x.CompanyId, Operator.Eq, company.Id)).First().K;

                    var places = Connection.GetList<Place>(Predicates.Field<Place>(x => x.CompanyId, Operator.Eq, company.Id)).ToList();
                    foreach (var place in places) {
                        osagoCompany.Places.Add((OsagoPlace)place);
                    }

                    var groups = Connection.GetList<CompanyGroup>(Predicates.Field<CompanyGroup>(x => x.CompanyId, Operator.Eq, company.Id)).ToList();
                    foreach (var group in groups) {
                        osagoCompany.Groups.Add((OsagoCompanyGroup)group);
                    }
                    osagoData.Companies.Add(osagoCompany);
                }
                return osagoData;
            }
            catch {
                return null;
            }
        }
    }
}