using System.Threading.Tasks;
using DAL.EF.Factory;

namespace DAL.EF.UoW
{
    public interface IUnitOfWork : IEFRepositoryCollection
    {
        void BeginTransaction();
        Task BeginTransactionAsync();
        void CommitTransaction();
        Task CommitTransactionAsync();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}