using System;
using System.Collections.Generic;
using DAL.Common.Factory;

namespace DAL.EF.Factory
{
    public class EFRepositoryFactory : IRepositoryFactory
    {
        protected readonly AppDbContext _dbContext;
        private readonly Dictionary<Type, object> _repoCache = new();

        public EFRepositoryFactory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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