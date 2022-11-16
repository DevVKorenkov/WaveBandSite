using WaveBand.Web.Models;
using WaveBand.Web.Services.Abstractions;
using System.Threading.Tasks;
using WaveBand.Web.Repositories.Abstractions;

namespace WaveBand.Web.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepository;

    public NewsService(INewsRepository newsRepository) 
    {
        _newsRepository = newsRepository;
    }

    public async Task<IEnumerable<NewsModel>> GetNewsAsync()
    {
        return await _newsRepository.GetAsync();
    }

    public async Task<NewsModel> GetOnewNewsAsync(int? id)
    {
        return await _newsRepository.GetOneAsync(id);
    }

    public async Task ChangeNewsAsync(NewsModel newsModel)
    {
        await _newsRepository.ChangeAsync(newsModel);
    }

    public async Task AddNewsAsync(NewsModel newsModel)
    {
        await _newsRepository.AddAsync(newsModel);
    }
}
