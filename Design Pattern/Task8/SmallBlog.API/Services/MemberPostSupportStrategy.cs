using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class MemberPostSupportStrategy : IPostSupportStrategy
{
    private const int MemberPostSupportScore = 1;
    private readonly BlogContext _context;

    public MemberPostSupportStrategy(BlogContext context)
    {
        _context = context;
    }
    
    public async Task AddSupportAsync(User author,  User supporter,  Post post)
    {
        author.Reputation += MemberPostSupportScore;
        _context.Users.Update(author);
        
        await _context.UserPostSupports.AddAsync(new UserPostSupport()
        {
            SupporterId = supporter.Id,
            PostId = post.Id,
        });
        
        await _context.SaveChangesAsync();
    }
}