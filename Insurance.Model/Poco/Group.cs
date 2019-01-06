using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Mode { get; set; }
    }
}