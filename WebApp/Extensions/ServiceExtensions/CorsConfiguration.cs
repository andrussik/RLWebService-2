using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Extensions.ServiceExtensions
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCors(
            this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });
            return services;
        }
    }
}