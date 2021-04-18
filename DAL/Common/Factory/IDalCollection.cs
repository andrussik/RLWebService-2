using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace DAL.Common.Factory
{
    public interface IDalCollection
    {
        public IUnitOfWork Uow { get; }
        public ISierraRepositoryCollection SierraRepo { get; }
        public IRiksRepositoryCollection RiksRepo { get; }
        public IUrramRepositoryCollection UrramRepo { get; }
        public IElasticRepositoryCollection ElasticRepo { get; }
    }
}