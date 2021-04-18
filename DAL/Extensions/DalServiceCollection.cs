using DAL.Common.Factory;
using DAL.EF;
using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DalServiceCollection
    {
        public static IServiceCollection AddDal(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:AzureSqlEdge"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISierraRepositoryCollection, SierraRepositoryCollection>();
            services.AddScoped<IRiksRepositoryCollection, RiksRepositoryCollection>();
            services.AddScoped<IUrramRepositoryCollection, UrramRepositoryCollection>();
            services.AddScoped<IElasticRepositoryCollection, ElasticRepositoryCollection>();
            services.AddScoped<IDalCollection, DalCollection>();
            
            return services;
        }
    }
}