namespace SmallBlog.API.Models;

public class Bundle
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public ICollection<BookBundle> BookBundles { get; set; } = new List<BookBundle>();
}