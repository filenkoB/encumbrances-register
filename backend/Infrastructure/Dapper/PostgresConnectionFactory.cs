using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Dapper
{
    public class PostgresConnectionFactory
    {
        public NpgsqlConnection Connection { get; private set; }

        public PostgresConnectionFactory(string connectionString)
        {
            Connection = new NpgsqlConnection(connectionString);
        }
    }
}
