using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("PlaceDefault")]
    public class PlaceDefault
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public double K { get; set; }
    }
}