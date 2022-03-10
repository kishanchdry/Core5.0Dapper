using Autofac;
using Communication.Mail;
using Communication.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Ioc;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Authorization.Policies;
using Web.Extensions;

namespace Web.Ioc
{
    /// <summary>
    /// 
    /// </summary>
    public static class ContainerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<SaveFormFileSerivce, SaveFormFileSerivce>();
            services.AddScoped<EmailFunctions, EmailFunctions>();
            services.AddScoped<EmailHelperCore, EmailHelperCore>();
            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();
            services.AddScoped<IAuthorizationHandler, CustomRequirePolicyHandler>();
            services.AddScoped<IExceptionLogginService, ExceptionLogginService>();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            services.AddHttpContextAccessor();
            services.RegisterServices(configuration);
        }
    }
}
