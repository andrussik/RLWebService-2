using BLL.Services;

namespace BLL.Factory
{
    public interface IServiceCollection
    {
        ISearchService Searches { get; }
        IAuthorService Authors { get; }
    }
}