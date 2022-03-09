using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IFactory
{
    public interface IRepositoryConfiguration
    {
        string GetDBConnectionString();
    }
}