using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaveBand.Web.Models
{
    public class NewsModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Required, StringLength(140, ErrorMessage = "Enter news' title", MinimumLength = 2)]
        public string Title { get; set; }

        [DisplayName("Short Description")]
        public int NewsShortId { get; set; }

        [ForeignKey("NewsShortId")]
        public NewsShortsModel Short { get; set; }

        [Required, StringLength(int.MaxValue, ErrorMessage = "Enter the news", MinimumLength = 10)]
        public string Body { get; set; }

        [DisplayName("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public AuthorModel Author { get; set; }
    }
}
