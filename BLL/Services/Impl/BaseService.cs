using BLL.Services.Interfaces;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Services.Impl
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UOW;
        protected readonly ISierraRepositoryCollection SierraRepo;
        protected readonly IRiksRepositoryCollection RiksRepo;
        protected readonly IUrramRepositoryCollection UrramRepo;
        protected readonly IElasticsearchRepositoryCollection ElasticRepo;

        public BaseService(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IElasticsearchRepositoryCollection elasticRepo
            )
        {
            UOW = uow;
            SierraRepo = sierraRepo;
            RiksRepo = riksRepo;
            UrramRepo = urramRepo;
            ElasticRepo = elasticRepo;
        }
    }
}