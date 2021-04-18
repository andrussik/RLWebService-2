using DAL.SearchEngine.Repositories;
using DAL.SearchEngine.Repositories.Impl;
using Nest;

namespace DAL.SearchEngine.Factory
{
    public class ElasticRepositoryCollection : ElasticRepositoryFactory, IElasticRepositoryCollection
    {
        public ElasticRepositoryCollection(IElasticClient elasticClient) : base(elasticClient)
        {
        }
        
        public IPublicationRepository Publications =>
            GetRepository(() => new PublicationRepository(_elasticClient));
    }
}