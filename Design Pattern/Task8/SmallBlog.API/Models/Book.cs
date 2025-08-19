namespace SmallBlog.API.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Summary { get; set; }
    public string ImageUrl { get; set; }
    public string Publisher { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }

    public ICollection<Bundle> Bundles { get; set; } = new List<Bundle>();
}