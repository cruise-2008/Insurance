using Insurance.Model.App.Osago;
using Insurance.Model.Poco;
using System.Collections.Generic;

namespace Insurance.Model.Interfaces
{
    public interface IOsagoService
    {
        OsagoData GetOsagoData();

        OsagoData GetOsagePlace(bool eu);

        double GetOsageCoefficient(bool isEU, bool isTaxi, bool isPrivilege, string placeId, int groupK);

    }
}
