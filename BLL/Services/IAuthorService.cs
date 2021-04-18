using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace BLL.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
    }
}