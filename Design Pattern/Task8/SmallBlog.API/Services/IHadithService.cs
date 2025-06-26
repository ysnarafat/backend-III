namespace SmallBlog.API.Services;

public interface IHadithService
{
    public Task<IEnumerable<string>> GetDailyHadiths();
}