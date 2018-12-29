using Insurance.Model.App.Osago;
using Insurance.Model.Poco;
using System.Collections.Generic;

namespace Insurance.Model.Interfaces
{
    public interface IOsagoService
    {
        OsagoData GetOsagoData();

        OsagoData GetOsagePlace(bool eu);
        //OsagoPlace GetOsagePlace(bool eu);
       // List<Place> GetOsagePlace(bool eu);


    }
}
