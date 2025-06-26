using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Data;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class BundleService: IBundleService
{
    private readonly BlogContext _context;

    public BundleService(BlogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooks(int bundleId)
    {
        var bundle = await _context.Bundles
            .Include(x => x.BookBundles)
            .ThenInclude(x => x.Book)
            .FirstOrDefaultAsync(x => x.Id == bundleId);

        return bundle?.BookBundles?.Select(x => x.Book) ?? [];
    }
}