using System;
using System.Collections.Generic;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        protected readonly IUnitOfWork Uow;
        protected readonly ISierraRepositoryCollection SierraRepo;
        protected readonly IRiksRepositoryCollection RiksRepo;
        protected readonly IUrramRepositoryCollection UrramRepo;
        protected readonly IElasticsearchRepositoryCollection ElasticRepo;
        
        private readonly Dictionary<Type, object> _serviceCache = new();

        protected ServiceFactory(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IElasticsearchRepositoryCollection elasticRepo
            )
        {
            Uow = uow;
            SierraRepo = sierraRepo;
            RiksRepo = riksRepo;
            UrramRepo = urramRepo;
            ElasticRepo = elasticRepo;
        }

        public TService GetService<TService>(Func<TService> serviceCreationMethod) 
            where TService : class
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var service))
            {
                return (TService) service;
            }

            var newServiceInstance = serviceCreationMethod();
            _serviceCache.Add(typeof(TService), newServiceInstance);
            return newServiceInstance;
        }
    }
}