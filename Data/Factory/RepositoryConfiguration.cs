using Data.IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factory
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        private readonly string _DBConnectionString;

        public RepositoryConfiguration(string DBConnectionString)
        {
            _DBConnectionString = DBConnectionString;
        }

        public string GetDBConnectionString()
        {
            return _DBConnectionString;
        }
    }
}
