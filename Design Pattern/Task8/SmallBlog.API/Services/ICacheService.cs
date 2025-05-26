namespace SmallBlog.API.Services;

public interface ICacheService<T, TKey> where T: class
{
    Task<T?> GetAsync(TKey key);
    Task SetAsync(TKey key, T value);
}
