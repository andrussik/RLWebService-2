using DAL.Elasticsearch.Repositories.Interfaces;
using Nest;

namespace DAL.Elasticsearch.Repositories.Impl
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly IElasticClient _elasticClient;

        public BaseRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
    }
}