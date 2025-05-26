using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Data;
using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.DTOs.Responses;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class PostService : IPostService
{
    private readonly BlogContext _context;
    private readonly SupportStrategyFactory _supportStrategyFactory;
    private readonly ICacheService<Post, int> _cacheService;

    public PostService(BlogContext context, 
        SupportStrategyFactory supportStrategyFactory,
        ICacheService<Post, int> cacheService)
    {
        _context = context;
        _supportStrategyFactory = supportStrategyFactory;
        _cacheService = cacheService;
    }

    public async Task<PostDto> GetPostAsync(int id)
    {
        var post = await _cacheService.GetAsync(id);

        if (post == null)
        {
            return null;
        }

        return new PostDto()
        {
            Id = post.Id,
            Content = post.Content,
            Title = post.Title,
            AuthorId = post.Author.Id,
            Author = post.Author.Name
        };
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
