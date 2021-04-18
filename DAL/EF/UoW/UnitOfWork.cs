using System.Threading.Tasks;
using DAL.EF.Factory;

namespace DAL.EF.UoW
{
    public class UnitOfWork : EFRepositoryCollection, IUnitOfWork
    {
        public UnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
        
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}