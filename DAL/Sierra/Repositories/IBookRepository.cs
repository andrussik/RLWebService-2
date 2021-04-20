using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Sierra;
using Microsoft.Win32.SafeHandles;
using Item = DTO.Sierra.Item;

namespace DAL.Sierra.Repositories
{
    public interface IBookRepository
    {
        Task<BibResponse> FindWithAllFieldsAsync(int minId, int maxId);
        Task<SearchResponse> FindAsync(string searchString);
        Task<string> GetMarcFileAsync(string link);
        Task<MarcFileLinkResponse> GetMarcFileLinkFromIdsAsync(IEnumerable<string> bookIds);
        Task<MarcFileLinkResponse> GetMarcFileLinkFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Bib>> GetBibsFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromBibIdRangeAsync(int minId, int maxId);
        Task<IEnumerable<Item>> GetItemsFromBibIdsAsync(IEnumerable<string> bibIds);
    }
}