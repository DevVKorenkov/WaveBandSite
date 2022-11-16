using Microsoft.EntityFrameworkCore;
using WaveBand.Web.Models;

namespace WaveBand.Web.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<NewsModel> NewsModel { get; set; }
    public DbSet<AuthorModel> AuthorModel { get; set; }
    public DbSet<SongModel> SongModel { get; set; }
    public DbSet<MemberModel> MemberModel { get; set; }

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    { 
        Database.EnsureCreated();
    }
}
