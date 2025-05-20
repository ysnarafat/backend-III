using System.ComponentModel.DataAnnotations;

namespace SmallBlog.API.DTOs.Requests;

public class CreateCommentDto
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public string Text { get; set; }
}
