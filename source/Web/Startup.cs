using DotNetCore.AspNetCore;
using DotNetCore.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreArchitecture.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseExceptionMiddleware();
            application.UseCorsAllowAny();
            application.UseHttps();
            application.UseAuthentication();
            application.UseResponseCompression();
            application.UseResponseCaching();
            application.UseStaticFiles();
            application.UseMvcWithDefaultRoute();
            application.UseHealthChecks();
            application.UseSwaggerDefault();
            application.UseSpa();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguration();
            services.AddLogger();
            services.AddCors();
            services.AddJsonWebToken();
            services.AddHash();
            services.AddAuthenticationJwtBearer();
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.AddMvcDefault();
            services.AddHealthChecks();
            services.AddSwaggerDefault();
            services.AddSpa();
            services.AddFileService();
            services.AddApplicationServices();
            services.AddDomainServices();
            services.AddDatabaseServices();
            services.AddContext();
        }
    }
}
