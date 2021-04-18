using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class BLLServiceCollection
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddScoped<Factory.IServiceCollection, Factory.ServiceCollection>();
            return services;
        }
        
        public static IServiceCollection AddBllSingleton(this IServiceCollection services)
        {
            services.AddSingleton<Factory.IServiceCollection, Factory.ServiceCollection>();
            return services;
        }
    }
}