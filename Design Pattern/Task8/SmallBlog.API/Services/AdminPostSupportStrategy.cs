using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class AdminPostSupportStrategy : IPostSupportStrategy
{
    private const int AdminPostSupportScore = 5;
    private readonly BlogContext _context;

    public AdminPostSupportStrategy(BlogContext context)
    {
        _context = context;
    }
    
    public async Task AddSupportAsync(User author,  User supporter,  Post post)
    {
        author.Reputation += AdminPostSupportScore;
        _context.Users.Update(author);
        
        await _context.UserPostSupports.AddAsync(new UserPostSupport()
        {
            PostId = post.Id,
            SupporterId = supporter.Id
        });

        await _context.SaveChangesAsync();
    }
}