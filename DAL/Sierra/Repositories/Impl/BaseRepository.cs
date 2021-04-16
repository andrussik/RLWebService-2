using System.Net.Http;
using DAL.Sierra.Repositories.Interfaces;

namespace DAL.Sierra.Repositories.Impl
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly HttpClient _httpClient;

        public BaseRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("sierra");
        }
    }
}