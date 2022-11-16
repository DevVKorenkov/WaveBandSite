using System.ComponentModel.DataAnnotations;

namespace WaveBand.Web.Models;

public class SongModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public string SongUrl { get; set; }
}
