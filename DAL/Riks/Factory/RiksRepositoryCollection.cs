using System.Net.Http;
using DAL.Common.Factory;

namespace DAL.Riks.Factory
{
    public class RiksRepositoryCollection : RepositoryFactory, IRiksRepositoryCollection
    {
        public RiksRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}