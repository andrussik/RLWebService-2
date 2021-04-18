using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace DAL.Common.Factory
{
    public class DalCollection : IDalCollection
    {
        public DalCollection(IUnitOfWork uow, ISierraRepositoryCollection sierraRepo, IRiksRepositoryCollection riksRepo, IUrramRepositoryCollection urramRepo, IElasticRepositoryCollection elasticRepo)
        {
            Uow = uow;
            SierraRepo = sierraRepo;
            RiksRepo = riksRepo;
            UrramRepo = urramRepo;
            ElasticRepo = elasticRepo;
        }

        public IUnitOfWork Uow { get; }
        public ISierraRepositoryCollection SierraRepo { get; }
        public IRiksRepositoryCollection RiksRepo { get; }
        public IUrramRepositoryCollection UrramRepo { get; }
        public IElasticRepositoryCollection ElasticRepo { get; }
    }
}