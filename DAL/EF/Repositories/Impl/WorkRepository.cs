using Domain.Entities;

namespace DAL.EF.Repositories.Impl
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}