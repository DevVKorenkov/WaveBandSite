using Microsoft.EntityFrameworkCore;
using WaveBand.Web.DataContext;
using WaveBand.Web.Models;
using WaveBand.Web.Repositories.Abstractions;
using WaveBand.Web.Services;
using WaveBand.Web.Services.Abstractions;
using WaveBand.Web.Configure;
using WaveBand.Web.Repositories;

const string _sqlConnectionString = "SqlConnectionString";

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<AppDataContext>(opt 
    => opt.UseSqlServer(builder.Configuration.GetConnectionString(_sqlConnectionString)));

services.SetSettingsFromSection<Artist>(configuration);

services.AddTransient<INewsRepository, NewsRepository>();
services.AddTransient<INewsService, NewsService>();

services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
