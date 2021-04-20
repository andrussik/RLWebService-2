using BLL.Services;
using BLL.Services.Impl;
using DAL.Common.Factory;
using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using Nest;

namespace BLL.Factory
{
    public class ServiceCollection : ServiceFactory, IServiceCollection
    {
        public ServiceCollection(IDalCollection dal) : base(dal)
        {
        }

        public ISearchService Searches =>
            GetService<ISearchService>(() => new SearchService(Dal));

        public IAuthorService Authors =>
        GetService<IAuthorService>(() => new AuthorService(Dal));
        
        public ISierraFetchService SierraFetchService =>
            GetService<ISierraFetchService>(() => new SierraFetchService(Dal));
    }
}