namespace SmallBlog.API.Models;

public class BookBundle
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int BundleId { get; set; }
    public Bundle Bundle { get; set; }
}