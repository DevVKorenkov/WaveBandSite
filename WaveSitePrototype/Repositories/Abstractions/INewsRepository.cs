using WaveBand.Web.Models;

namespace WaveBand.Web.Repositories.Abstractions
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsModel>> GetAsync();
        Task<NewsModel> GetOneAsync(int? id);
        Task ChangeAsync(NewsModel newNews);
        Task AddAsync(NewsModel newNews);
    }
}
