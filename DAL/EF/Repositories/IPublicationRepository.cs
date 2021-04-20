using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.EF.Repositories
{
    public interface IPublicationRepository : IBaseRepository<Publication>
    {
        string? GetMaxSierraId();
    }
}