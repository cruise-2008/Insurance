using System.Data.SqlClient;
using Insurance.Model.Interfaces;

namespace Insurance.Services.DataSourse
{
    public class BaseService : IBaseService
    {
        public SqlConnection Connection { get; set; }
    }
}
