namespace SmallBlog.API.Models;

public class UserPostSupport
{
    public int SupporterId { get; set; }
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public User Supporter { get; set; }
    public Post Post { get; set; }
}