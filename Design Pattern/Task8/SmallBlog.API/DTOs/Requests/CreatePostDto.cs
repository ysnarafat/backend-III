using System.ComponentModel.DataAnnotations;

namespace SmallBlog.API.DTOs.Requests;

public class CreatePostDto
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Content { get; set; }
}
