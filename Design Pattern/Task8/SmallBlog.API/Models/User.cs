namespace SmallBlog.API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public long Reputation { get; set; }
    
    public ICollection<UserPostSupport> UserPostSupports { get; set; } = new List<UserPostSupport>();
}
