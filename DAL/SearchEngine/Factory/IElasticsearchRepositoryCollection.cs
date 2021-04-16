using DAL.Elasticsearch.Repositories.Interfaces;

namespace DAL.Elasticsearch.Factory
{
    public interface IElasticsearchRepositoryCollection
    {
        IPublicationRepository Publications { get; }
    }
}