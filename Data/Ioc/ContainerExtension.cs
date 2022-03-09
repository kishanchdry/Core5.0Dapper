using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Data.Factory;
using Data.IFactory;
using Microsoft.Extensions.Configuration;

namespace Data.Ioc
{
    public static class ContainerExtension
    {
        public static void RegisterRepositories(this ContainerBuilder builder, IConfiguration configuration)
        {
            var DBConnectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(DBConnectionString)) throw new Exception("Empty Database connection string");

            builder.Register(ctx => new RepositoryConfiguration(DBConnectionString))
                .As<IRepositoryConfiguration>()
                .SingleInstance();

            builder.RegisterType<DbConnectionFactory>().As<IDbConnectionFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
        }
    }
}
