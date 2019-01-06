using Insurance.Model.Poco;

namespace Insurance.Model.App.Osago
{
    public class OsagoPlace
    {
        public string Name { get; set; }
        public string PlaceGoogleId { get; set; }
        public double K { get; set; }


        public static explicit operator OsagoPlace(Place place)
        {
            return new OsagoPlace
            {
                Name = place.Name,
                PlaceGoogleId = place.PlaceGoogleId,
                K = place.K
            };
        }
    }
}
