using Microsoft.AspNetCore.Mvc;
using WaveBand.Web.Services.Abstractions;

namespace WaveBand.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IJsonService _jsonService;

        public AdminController(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}
