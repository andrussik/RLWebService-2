using DAL.Sierra.Repositories;

namespace DAL.Sierra.Factory
{
    public interface ISierraRepositoryCollection
    {
        IBookRepository Books { get; }
    }
}