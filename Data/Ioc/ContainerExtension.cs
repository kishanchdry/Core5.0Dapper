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

            services.AddScoped(typeof(IRepositoryConfiguration),ctx => new RepositoryConfiguration(DBConnectionString));

            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IGenericDataRepository<>), typeof(GenericDataRepository<>));
            //services.AddScoped(typeof(GenericDataRepository<>), typeof(GenericDataRepository<>));
            //builder.RegisterType<IGenericDataRepository<>, GenericDataRepository<>>();
        }
    }
}
