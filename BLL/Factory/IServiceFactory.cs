using System;

namespace BLL.Factory
{
    public interface IServiceFactory
    {
        TService GetService<TService>(Func<TService> serviceCreationMethod)
            where TService : class;
    }
}