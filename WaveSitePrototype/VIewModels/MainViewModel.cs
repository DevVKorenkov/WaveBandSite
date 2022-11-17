using WaveBand.Web.Models;

namespace WaveBand.Web.ViewModels
{
    public class MainViewModel
    {
        public MainPageModel MainPage { get; set; }

        public IEnumerable<NewsShortsModel> NewsShorts { get; set; }
    }
}
