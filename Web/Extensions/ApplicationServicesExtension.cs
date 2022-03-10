using Web.Authorization.Policies;
using Communication.Mail;
using Communication.Utilities;
using Data.IRepository;
using Data.Repository.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Services.Generic;
using Services.IServices;
using Services.IServices.Identity;
using Services.Services;
using Services.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.IRepository.IGeneric;

namespace Web.Extensions
{
    /// <summary>
    /// Services injection resolver
    /// </summary>
    public static class ApplicationServicesExtension
    {
        /// <summary>
        /// Add services for injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericDataRepository<>), typeof(GenericDataRepository<>));
            services.AddTransient(typeof(GenericDataRepository<>), typeof(GenericDataRepository<>));

            services.AddScoped<SaveFormFileSerivce, SaveFormFileSerivce>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<EmailFunctions, EmailFunctions>();
            services.AddScoped<EmailHelperCore, EmailHelperCore>();


            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();
            services.AddScoped<IAuthorizationHandler, CustomRequirePolicyHandler>();

            services.AddSingleton<IExceptionLogginService, ExceptionLogginService>();

            return services;
        }
    }
}
