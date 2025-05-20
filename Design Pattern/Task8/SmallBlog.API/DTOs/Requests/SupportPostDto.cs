using System.ComponentModel.DataAnnotations;

namespace SmallBlog.API.DTOs.Requests;

public class SupportPostDto
{
    public int PostId { get; set; }
    [Required]
    public int SupporterId { get; set; }
}