using Insurance.Model.Poco;
using System.Collections.Generic;

namespace Insurance.Model.App.Osago
{
    public class OsagoPlace
    {
        public string Name { get; set; }
        public string PlaceGoogleId { get; set; }
        public double K { get; set; }
        public bool IsEU { get; set; }
        public List<OsagoPlace> place { get; set; }
        public List<OsagoCompany> company { get; set; }
        public static explicit operator OsagoPlace(Place place)
        {
            return new OsagoPlace
            {
                Name = place.Name,
                PlaceGoogleId = place.PlaceGoogleId,
                K = place.K,
                IsEU=place.IsEU
            };
        }
    }
}
