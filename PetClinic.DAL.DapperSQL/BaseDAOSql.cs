using PetClinic.DAL.DapperSQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.DapperSQL
{
    public class BaseDAOSql
    {
        private readonly IConnectionFactory _connectionFactory;
        protected BaseDAOSql(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using(var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() timeout", ex);
            }
            catch(SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() not timeout", ex);
            }
        }

    }
}
