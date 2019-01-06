using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("Settings")]
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public double Bp { get; set; }
    }
}