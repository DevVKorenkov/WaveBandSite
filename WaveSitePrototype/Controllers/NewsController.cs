using Microsoft.AspNetCore.Mvc;
using WaveBand.Web.Models;
using WaveBand.Web.Services.Abstractions;

namespace WaveBand.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService) 
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNewsAsync();

            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                await _newsService.AddNewsAsync(newsModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newsModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            var news = await _newsService.GetOnewNewsAsync(id);

            return news == null ? NotFound() : View(news);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(NewsModel newsModel)
        {
            if(newsModel == null || !ModelState.IsValid)
            {
                return View(newsModel);
            }

            await _newsService.ChangeNewsAsync(newsModel);

            return RedirectToAction("Index");
        }
    }
}
