using DAL.Common.Factory;
using DAL.EF.Repositories;
using IPublicationRepository = DAL.EF.Repositories.IPublicationRepository;

namespace DAL.EF.Factory
{
    public interface IEFRepositoryCollection : IRepositoryFactory
    {
        IPublicationRepository Publications { get; }
        IAuthorRepository Authors { get; }
        IWorkRepository Works { get; }
        IWorkAuthorRepository WorkAuthors { get; }
    }
}