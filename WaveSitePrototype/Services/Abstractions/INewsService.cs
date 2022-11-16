using WaveBand.Web.Models;

namespace WaveBand.Web.Services.Abstractions
{
    public interface INewsService
    {
        Task<IEnumerable<NewsModel>> GetNewsAsync();
        Task<NewsModel> GetOnewNewsAsync(int? id);
        Task ChangeNewsAsync(NewsModel newsModel);
        Task AddNewsAsync(NewsModel newsModel);
    }
}
