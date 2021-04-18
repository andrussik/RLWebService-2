using Domain.Entities;

namespace DAL.EF.Repositories.Impl
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}