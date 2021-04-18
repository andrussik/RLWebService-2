using DAL.EF.Impl;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using Handlers.TokenHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class HandlersServiceCollection
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<SierraTokenHandler>();
            services.AddTransient<RiksTokenHandler>();
            services.AddTransient<UrramTokenHandler>();

            return services;
        }
    }
}