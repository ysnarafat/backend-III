namespace SmallBlog.API.Models;

public class Bundle
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}