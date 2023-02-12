using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using BL.Services;

namespace BL
{
    public class Configuration
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Configuration(IConfiguration conf)
        {
            _configuration = conf;
            _connectionString = _configuration.GetConnectionString("CoreContext") ?? "";
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public ServiceFactory GetFactory()
            => new(_configuration);

    }
}
