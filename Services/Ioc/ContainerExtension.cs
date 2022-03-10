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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<IExceptionLogginService, ExceptionLogginService>();
            services.AddScoped<ICURDService, CURDService>();
        }
    }
}
