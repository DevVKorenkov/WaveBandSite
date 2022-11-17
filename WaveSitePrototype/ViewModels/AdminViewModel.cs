using WaveBand.Web.Models;

namespace WaveBand.Web.ViewModels
{
    public class AdminViewModel
    {
        public MainPageModel MainPage { get; set; }

        public IEnumerable<MemberModel> Members { get; set; }

        public IEnumerable<AuthorModel> Authors { get; set; }

        public IEnumerable<NewsShortsModel> ShortsNews { get; set; }
    }
}
