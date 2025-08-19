using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public interface IBundleService
{
    /// <summary>
    /// Get all the books within a bundle by id
    /// </summary>
    /// <param name="bundleId"></param>
    /// <returns>Books within a bundle</returns>
    public Task<IEnumerable<Book>> GetBooksAsync(int bundleId);
}