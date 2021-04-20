using System.Threading.Tasks;
using DTO.Sierra;

namespace BLL.Services
{
    public interface ISierraFetchService
    {
        Task<BibResponse> GetAndSavePublication();
    }
}