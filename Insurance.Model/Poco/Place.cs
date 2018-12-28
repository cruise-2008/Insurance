using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("Place")]
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceGoogleId { get; set; }
        public int CompanyId { get; set; }
        public double K { get; set; }
        public bool IsEU {get; set; }
    }
}