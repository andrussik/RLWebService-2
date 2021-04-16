using System.Net.Http;
using DAL.Factory;
using DAL.Sierra.Repositories.Impl;
using DAL.Sierra.Repositories.Interfaces;

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