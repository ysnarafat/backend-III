using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class BundleService : IBundleService
{
    private readonly BlogContext _context;
    private readonly ICacheService<Bundle, int> _cacheService;

    public BundleService(BlogContext context, ICacheService<Bundle, int> cacheService)
    {
        _context = context;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(int bundleId)
    {
        var bundle = await _cacheService.GetAsync(bundleId);

        return bundle?.Books.Select(x =>
        {
            x.Bundles = [];

            return x;
        }) ?? [];
    }
}