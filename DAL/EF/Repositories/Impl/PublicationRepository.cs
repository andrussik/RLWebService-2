using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories.Impl
{
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public string? GetMaxSierraId()
        {
            var sql = $@"SELECT MAX(CAST(SierraID AS bigint)) FROM Publications
                        WHERE SierraID NOT LIKE '%[a-z]%'
                        AND ISNUMERIC(SierraID) = 1";
            var result = RawSqlQuery<string>(sql, x => x[0].ToString()!).FirstOrDefault();
            return result;
        }
    }
}