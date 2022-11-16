using System.ComponentModel.DataAnnotations;

namespace WaveBand.Web.Models
{
    public class AuthorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
