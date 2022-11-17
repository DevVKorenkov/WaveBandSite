using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaveBand.Web.ViewModels;
using System.Text.Json;
using WaveBand.Web.DataContext;
using WaveBand.Web.Services.Abstractions;
using WaveBand.Web.Models;
using System.Linq;

namespace WaveBand.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService _newsService;
        public HomeController(ILogger<HomeController> logger, 
            INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNewsAsync();

            var newsShorts = news.Select(x => x.Short);

            var mainViewModel = new MainViewModel
            {
                NewsShorts = newsShorts,
            };

            return View(mainViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}