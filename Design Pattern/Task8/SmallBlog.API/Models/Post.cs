namespace SmallBlog.API.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public User Author { get; set; }
    
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<UserPostSupport> UserPostSupports { get; set; } = new List<UserPostSupport>(); 
}
