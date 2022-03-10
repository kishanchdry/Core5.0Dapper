using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Data.Factory;
using Data.IFactory;
using Data.IRepository;
using Data.IRepository.IGeneric;
using Data.Repository;
using Data.Repository.GenericRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Ioc
{
    public static class ContainerExtension
    {
        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var DBConnectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(DBConnectionString)) throw new Exception("Empty Database connection string");

            services.AddSingleton(typeof(IRepositoryConfiguration),ctx => new RepositoryConfiguration(DBConnectionString));

            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();
            //builder.RegisterType<IGenericDataRepository<>, GenericDataRepository<>>();
        }
    }
}
