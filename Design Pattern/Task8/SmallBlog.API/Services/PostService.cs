using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Data;
using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class PostService : IPostService
{
    private readonly BlogContext _context;
    private readonly SupportStrategyFactory _supportStrategyFactory;

    public PostService(BlogContext context, SupportStrategyFactory supportStrategyFactory)
    {
        _context = context;
        _supportStrategyFactory = supportStrategyFactory;
    }

    public async Task<bool> SupportPostAsync(SupportPostDto dto)
    {
        var existingEntry = 
            await _context.UserPostSupports.FirstOrDefaultAsync(x => x.PostId == dto.PostId
                && x.SupporterId == dto.SupporterId);

        if (existingEntry is not null)
        {
            return false;
        }
        
        var post = await _context.Posts
            .Include(x => x.Author)
            .FirstOrDefaultAsync(x => x.Id == dto.PostId);

        if (post == null)
        {
            return false;
        }
        
        var supporter = await _context.Users.FindAsync(dto.SupporterId);
        
        if (supporter == null)
        {
            return false;
        }
        
        var strategy = _supportStrategyFactory.GetPostSupportStrategy(supporter);
        
        await strategy.AddSupportAsync(post.Author, supporter, post);

        return true;
    }
}
