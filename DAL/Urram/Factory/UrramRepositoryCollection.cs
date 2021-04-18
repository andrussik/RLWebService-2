using System.Net.Http;
using DAL.Common.Factory;

namespace DAL.Urram.Factory
{
    public class UrramRepositoryCollection : RepositoryFactory, IUrramRepositoryCollection
    {
        public UrramRepositoryCollection(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}