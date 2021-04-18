using System.Threading.Tasks;
using DAL.EF.Factory;

namespace DAL.EF.UoW
{
    public interface IUnitOfWork : IEFRepositoryCollection
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}