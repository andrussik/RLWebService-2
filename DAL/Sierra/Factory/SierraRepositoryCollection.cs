using System.Net.Http;
using DAL.Common.Factory;
using DAL.Sierra.Repositories;
using DAL.Sierra.Repositories.Impl;

namespace DAL.Sierra.Factory
{
    public class SierraRepositoryCollection : RepositoryFactory, ISierraRepositoryCollection
    {
        public SierraRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public IBookRepository Books =>
            GetRepository(() => new BookRepository(_clientFactory));
    }
}