using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.PublicApi;

namespace BLL.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Book>> SearchBooksAsync(SearchRequestDTO searchRequestDTO);
        Task<IEnumerable<Book>> FindAsync(string searchString);
        Task<IEnumerable<Book>> ElasticFindAsync(string searchString);
        Task ElasticIndexResultAsync(string searchString);
        Task IndexDataFromSierraToElasticsearch();
    }
}