using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Common.Factory;
using DAL.EF.UoW;
using DAL.Riks.Factory;
using DAL.SearchEngine.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using Domain.Entities;

namespace BLL.Services.Impl
{
    public class AuthorService : BaseService, IAuthorService
    {
        public AuthorService(IDalCollection dal) : base(dal)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await Uow.Authors.GetAllAsync();
        }
    }
}