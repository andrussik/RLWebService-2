using System;
using System.Threading.Tasks;
using DAL.Common.Factory;
using DTO.Sierra;

namespace BLL.Services.Impl
{
    public class SierraFetchService : BaseService, ISierraFetchService
    {
        public SierraFetchService(IDalCollection dal) : base(dal)
        {
        }
        
        public async Task<BibResponse> GetAndSavePublication()
        {
            var maxSierraId = Uow.Publications.GetMaxSierraId();
            var maxId = int.TryParse(maxSierraId, out var result) ? result : 1000000;
            var bibs = await SierraRepo.Books.FindWithAllFieldsAsync(maxId, maxId + 2000);
            return bibs;
            Console.WriteLine(bibs?.Entries?.Count);
        }
    }
}