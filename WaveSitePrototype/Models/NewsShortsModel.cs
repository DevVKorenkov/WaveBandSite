using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaveBand.Web.Models;

public class NewsShortsModel
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(280, ErrorMessage = "Enter short description' title", MinimumLength = 2)]
    public string ShortDescription { get; set; }
}
