using DAL.SearchEngine.Repositories;

namespace DAL.SearchEngine.Factory
{
    public interface IElasticRepositoryCollection
    {
        IPublicationRepository Publications { get; }
    }
}