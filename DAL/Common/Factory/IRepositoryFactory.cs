using System;

namespace DAL.Common.Factory
{
    public interface IRepositoryFactory
    {
        TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class;
    }
}