using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using Nest;

namespace BLL.Factory
{
    public class ServiceCollection : ServiceFactory, IServiceCollection
    {
        public ServiceCollection(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IElasticsearchRepositoryCollection elasticRepo
        ) : base(uow, sierraRepo, riksRepo, urramRepo, elasticRepo)
        {
        }

        public IBookService Books =>
            GetService<IBookService>(() => new BookService(Uow, SierraRepo, RiksRepo, UrramRepo, ElasticRepo));
    }
}