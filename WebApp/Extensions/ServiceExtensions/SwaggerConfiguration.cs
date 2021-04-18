using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApp.Extensions.ServiceExtensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApp", Version = "v1"});
            });
            return services;
        }
    }
}