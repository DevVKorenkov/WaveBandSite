using WaveBand.Web.Models;

namespace WaveBand.Web.VIewModels
{
    public class MainViewModel
    {
        public string LogoPath { get; set; }

        public string Definition { get; set; }

        public List<MemberModel> MemberModels { get; set; }
    }
}
