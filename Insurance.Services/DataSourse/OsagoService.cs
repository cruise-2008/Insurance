using System.Linq;
using DapperExtensions;
using Insurance.Model.App.Osago;
using Insurance.Model.Interfaces;
using Insurance.Model.Poco;
using System.Collections.Generic;

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
        //public OsagoData GetOsagePlace(bool eu)
        //{
        //    try
        //    {
        //        var result = new OsagoData();
        //        var places = Connection.GetList<Place>(Predicates.Field<Place>(x => x.IsEU, Operator.Eq, true)).ToList();

        //        foreach (var place in places)
        //        {
        //            var osago = (OsagoPlace)place;
        //            var europe = Connection.GetList<Company>(Predicates.Field<Company>(x => x.Id, Operator.Eq, place.CompanyId)).ToList();
        //            foreach (var e in europe)
        //            {
        //                var osagocompany = (OsagoCompany)e;
        //                result.Companies.Add(osagocompany);
        //            }

        //            result.Places.Add(osago);
        //        }
        //        var mode = "auto";
        //        var europe1 = Connection.GetList<Group>(Predicates.Field<Group>(x => x.Mode, Operator.Eq, mode)).Select(x=>x.K).Min();
        //        result.coefficient = europe1;
        //        return result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        public OsagoData GetOsagePlace(bool eu)
        {
            try
            {
                var result = new OsagoData();
                var places = Connection.GetList<Place>(Predicates.Field<Place>(x => x.IsEU, Operator.Eq, true)).ToList();
                var co = places.Where(x=>x.K==places.Min(y=>y.K)).Select(x => x.CompanyId);
                double lowest_price = places.Min(c => c.K);
                var europe = Connection.GetList<Company>(Predicates.Field<Company>(x => x.Id, Operator.Eq, co)).FirstOrDefault();
                var mode = "auto";
                var Mode = Connection.GetList<Group>(Predicates.Field<Group>(x => x.Mode, Operator.Eq, mode)).Select(x => x.K).Min();
                result.coefficient = Mode;
                result.K = lowest_price;
                result.osago = (OsagoCompany)europe;

                return result;
            }
            catch
            {
                return null;
            }
        }

    }
}