namespace SmallBlog.API.DTOs.Responses;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; }
}
