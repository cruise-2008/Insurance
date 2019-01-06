using System;
using Dapper.Contrib.Extensions;

namespace Insurance.Model.Poco
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public Guid PublicKey { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public double Commission { get; set; }
        public double Ktaxi { get; set; }
        public double Kprivileges { get; set; }
        public double K0 { get; set; }
        public double K1000 { get; set; }
        public double K2000 { get; set; }
        public bool IsEnabled { get; set; }

    }
}