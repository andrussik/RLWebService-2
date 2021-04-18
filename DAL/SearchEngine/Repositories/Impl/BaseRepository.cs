using Nest;

namespace DAL.SearchEngine.Repositories.Impl
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