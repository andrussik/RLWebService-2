using BLL.Extensions;
using DAL.Extensions;
using IdentityServerClient.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using WebApp.BackgroundTasks;

namespace WebApp.Extensions.ServiceExtensions
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<TimedHostedService>();

            services.AddControllers();
            services.AddIdentityServerClients();
            services.AddDal(configuration);
            services.AddBll();
            services.AddHttpClients(configuration);
            services.AddCors();
            services.AddSwagger(configuration);
            services.AddSingleton<IElasticClient, ElasticClient>();

            return services;
        }
    }
}