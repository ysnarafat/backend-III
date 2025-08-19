using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services
{
    public class BundleCacheService : ICacheService<Bundle, int>
    {
        private IMemoryCache _cache;
        private readonly BlogContext _context;

        public BundleCacheService(BlogContext context)
        {
            _context = context;
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<Bundle?> GetAsync(int key)
        {
            var cacheKey = GetCacheKey(key);
            _cache.TryGetValue(cacheKey, out Bundle? bundle);

            if (bundle is not null)
            {
                return bundle;
            }

            bundle = await _context.Bundles
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == key);

            if (bundle != null)
            {
                await SetAsync(key, bundle);
            }

            return bundle;
        }

        public async Task SetAsync(int key, Bundle value)
        {
            var cacheKey = GetCacheKey(key);

            _cache.Set(cacheKey,
                value,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
        }

        private string GetCacheKey(int id) => $"{nameof(Bundle)}:{id}";
    }
}
