using System.Data.SqlClient;

namespace PetClinic.DAL.DapperSQL.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
