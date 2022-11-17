using Microsoft.AspNetCore.Mvc;
using WaveBand.Web.Models;
using WaveBand.Web.Services.Abstractions;
using WaveBand.Web.ViewModels;
using static System.IO.File;

namespace WaveBand.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IJsonService _jsonService;
        private IWebHostEnvironment _env;

        public AdminController(INewsService newsService,
            IJsonService jsonService,
            IWebHostEnvironment env)
        {
            _newsService = newsService;
            _jsonService = jsonService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            AdminViewModel adminViewModel;

            var path = $"{_env.WebRootPath}{GeneralPathes.GeneralPath}MainPage.json";

            if (Exists(path))
            {
                var mainPageModel = _jsonService.GetJson<MainPageModel>(path);
            }

            adminViewModel = new AdminViewModel
            {
                MainPage = Exists(path) ? _jsonService.GetJson<MainPageModel>(path) : new MainPageModel(),
                ShortsNews = (await _newsService.GetNewsAsync()).Select(x => x.Short),
            };

            return View(adminViewModel);
        }

        [HttpGet]
        public async Task <IActionResult> EditMain()
        {
            var news = await _newsService.GetNewsAsync();

            return View(news);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditMainPost(MainPageModel mainPage)
        {
            if (ModelState.IsValid)
            {
                var path = $"{_env.WebRootPath}{GeneralPathes.GeneralPath}MainPage.json";

                _jsonService.SaveJson(mainPage, path);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditNews()
        {
            var news = await _newsService.GetNewsAsync();

            return View(news);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNewsPost(NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                await _newsService.ChangeNewsAsync(newsModel);

                return RedirectToAction("EditNews");
            }

            return View(newsModel);
        }
    }
}
