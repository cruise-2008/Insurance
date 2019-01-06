using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("CompanyGroup")]
    public class CompanyGroup
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int GroupId { get; set; }
        public double K { get; set; }
    }
}