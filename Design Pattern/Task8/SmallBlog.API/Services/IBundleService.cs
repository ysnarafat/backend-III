using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public interface IBundleService
{
    public Task<IEnumerable<Book>> GetBooks(int bundleId);
}