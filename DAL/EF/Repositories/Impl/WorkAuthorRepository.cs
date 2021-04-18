using Domain.Entities;

namespace DAL.EF.Repositories.Impl
{
    public class WorkAuthorRepository : BaseRepository<WorkAuthor>, IWorkAuthorRepository
    {
        public WorkAuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}