using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IFactory
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDBConnection();
    }
}
