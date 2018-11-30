using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace EBikeShop.Server
{
    public class SqliteSession : IDbSession
    {
        private readonly IConfiguration _config;

        public SqliteSession(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            return new SqliteConnection(GetConnectionString());
        }
    }
}
