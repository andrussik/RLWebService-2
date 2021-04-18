using System;
using System.Collections.Generic;
using DAL.Common.Factory;
using Nest;

namespace DAL.SearchEngine.Factory
{
    public class ElasticRepositoryFactory : IRepositoryFactory
    {
        protected readonly IElasticClient _elasticClient;
        private readonly Dictionary<Type, object> _repoCache = new();

        public ElasticRepositoryFactory(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class
        {
            if (_repoCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository) repo;
            }
        
            var newRepoInstance = repoCreationMethod();
            _repoCache.Add(typeof(TRepository), newRepoInstance);
            return newRepoInstance;
        }
    }
}