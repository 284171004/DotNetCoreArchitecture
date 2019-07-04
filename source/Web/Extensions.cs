using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetCoreArchitecture.Web
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMatchingInterface(typeof(IUserApplicationService).Assembly);
        }

        public static void AddContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            var connectionString = configuration.GetConnectionString(nameof(Context));

            services.AddDbContextMigrate<Context>(x => x.ConfigureWarningsAsErrors().UseSqlServer(connectionString));
        }

        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddMatchingInterface(typeof(IUnitOfWork).Assembly);
        }

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddMatchingInterface(typeof(IUserDomainService).Assembly);
        }

        public static void AddHash(this IServiceCollection services)
        {
            services.AddHash(10000, 128);
        }

        public static void AddJsonWebToken(this IServiceCollection services)
        {
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
        }

        public static void AddSpa(this IServiceCollection services)
        {
            services.AddSpaStaticFiles("Frontend/dist");
        }

        public static void UseHealthChecks(this IApplicationBuilder application)
        {
            application.UseHealthChecks("/health");
        }

        public static void UseSpa(this IApplicationBuilder application)
        {
            application.UseSpaAngularServer("Frontend", "development");
        }
    }
}
