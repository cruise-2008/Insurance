using System.Data.SqlClient;

namespace Insurance.Model.Interfaces
{
    public interface IBaseService
    {
        SqlConnection Connection { get; set; }
    }
}
