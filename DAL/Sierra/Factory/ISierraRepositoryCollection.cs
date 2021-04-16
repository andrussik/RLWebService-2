using DAL.Sierra.Repositories.Interfaces;

namespace DAL.Sierra.Factory
{
    public interface ISierraRepositoryCollection
    {
        IBookRepository Books { get; }
    }
}