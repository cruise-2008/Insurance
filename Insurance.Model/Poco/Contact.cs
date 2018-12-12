using System;
using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public Guid PublicKey { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public bool IsEnabled { get; set; }
    }
}
