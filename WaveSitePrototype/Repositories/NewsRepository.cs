using Microsoft.EntityFrameworkCore;
using WaveBand.Web.DataContext;
using WaveBand.Web.Models;
using WaveBand.Web.Repositories.Abstractions;

namespace WaveBand.Web.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDataContext _db;

        public NewsRepository(AppDataContext db)
        {
            _db = db;
        }

        public async Task<NewsModel> GetOneAsync(int? id)
        {
            var news = await _db.NewsModel.FirstOrDefaultAsync(x => x.Id == id);

            return news;
        }

        public async Task<IEnumerable<NewsModel>> GetAsync()
        {
            var sortedNews = await Task.Run(() => _db.NewsModel.Include(x => x.Author).OrderByDescending(x => x.Created));

            return sortedNews;
        }

        public async Task ChangeAsync(NewsModel newNews)
        {
            _db.NewsModel.Update(newNews);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddAsync(NewsModel newNews)
        {
            await _db.NewsModel.AddAsync(newNews);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
