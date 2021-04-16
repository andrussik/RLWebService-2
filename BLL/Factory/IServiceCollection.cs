using BLL.Services.Interfaces;

namespace BLL.Factory
{
    public interface IServiceCollection
    {
        IBookService Books { get; }
    }
}