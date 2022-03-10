using Autofac;
using Data.Ioc;
using Microsoft.Extensions.Configuration;
using Services.IServices;
using Services.IServices.Identity;
using Services.Services;
using Services.Services.Identity;
using Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Ioc
{
    public static class ContainerExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<ISignInService, SignInService>();
            services.AddSingleton<IExceptionLogginService, ExceptionLogginService>();
            //builder.RegisterType(typeof(IGenericService<>), typeof(GenericService<>));
        }
    }
}
