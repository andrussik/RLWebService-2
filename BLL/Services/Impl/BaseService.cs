using DAL.Common.Factory;
using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Services.Impl
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork Uow;
        protected readonly ISierraRepositoryCollection SierraRepo;
        protected readonly IRiksRepositoryCollection RiksRepo;
        protected readonly IUrramRepositoryCollection UrramRepo;
        protected readonly IElasticRepositoryCollection ElasticRepo;

        public BaseService(IDalCollection dal)
        {
            Uow = dal.Uow;
            SierraRepo = dal.SierraRepo;
            RiksRepo = dal.RiksRepo;
            UrramRepo = dal.UrramRepo;
            ElasticRepo = dal.ElasticRepo;
        }
    }
}