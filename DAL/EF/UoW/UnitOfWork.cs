using System.Threading.Tasks;
using DAL.EF.Factory;

namespace DAL.EF.UoW
{
    public class UnitOfWork : EFRepositoryCollection, IUnitOfWork
    {
        public UnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
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