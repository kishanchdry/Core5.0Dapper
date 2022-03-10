using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Ioc
{
    public static class ContainerExtension
    {
        public static void RegisterWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices(configuration);
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
