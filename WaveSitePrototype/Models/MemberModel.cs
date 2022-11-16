using System.ComponentModel.DataAnnotations;

namespace WaveBand.Web.Models;

public class MemberModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Image { get; set; }
}
