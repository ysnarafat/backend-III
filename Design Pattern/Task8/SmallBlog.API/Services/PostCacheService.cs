using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class PostCacheService : ICacheService<Post, int>
{
    private IMemoryCache _cache;
    private readonly BlogContext _context;

    public PostCacheService(BlogContext context)
    {
        _context = context;
        _cache = new MemoryCache(new MemoryCacheOptions());
    }
    
    public async Task<Post?> GetAsync(int key)
    {
        var cacheKey = GetCacheKey(key);
        _cache.TryGetValue(cacheKey, out Post? post);

        if (post is not null)
        {
            return post;
        }
        
        post = await _context.Posts
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Id == key);
            
        if (post != null)
        {
            await SetAsync(key, post);
        }

        return post;
    }

    public async Task SetAsync(int key, Post value)
    {
        var cacheKey = GetCacheKey(key);
        
        _cache.Set(cacheKey, 
            value, 
            new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
            });
    }
    
    private string GetCacheKey(int id) => $"{nameof(Post)}:{id}";
}