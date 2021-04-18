using IdentityServerClient.TokenHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerClient.Extensions
{
    public static class IdentityServerClientServiceCollection
    {
        public static IServiceCollection AddIdentityServerClients(this IServiceCollection services)
        {
            services.AddScoped<IIdentityServerClient, IdentityServerClient>();
            
            services.AddTransient<SierraTokenHandler>();
            services.AddTransient<RiksTokenHandler>();
            services.AddTransient<UrramTokenHandler>();
            
            return services;
        }
    }
}