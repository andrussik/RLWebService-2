using System;
using System.Collections.Generic;
using DAL.Common.Factory;
using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;

namespace BLL.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        protected readonly IDalCollection Dal;
        
        private readonly Dictionary<Type, object> _serviceCache = new();

        protected ServiceFactory(IDalCollection dal)
        {
            Dal = dal;
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