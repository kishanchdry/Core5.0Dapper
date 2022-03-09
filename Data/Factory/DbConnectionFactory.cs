using Data.IFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factory
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        public DbConnectionFactory(IRepositoryConfiguration repositoryConfiguration)
        {
            _repositoryConfiguration = repositoryConfiguration;
        }

        public IDbConnection CreateDBConnection()
        {
            return new SqlConnection(_repositoryConfiguration.GetDBConnectionString());
        }
    }
}
