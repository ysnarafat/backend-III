using SmallBlog.External.AsSunnahFoundation;

namespace SmallBlog.API.Services;

public class HadithService: IHadithService
{
    private const int TimesToRetry = 3; 
    public async Task<IEnumerable<string>> GetDailyHadiths()
    {
        var hadith = new Hadith();
        var allHadiths = hadith.GetAllHadiths();

        int retried = 0;
        while (allHadiths.Count() == 0 && retried < TimesToRetry )
        {
            allHadiths = hadith.GetAllHadiths();
            retried++;
            Task.Delay(1000).Wait();
        }
        
        return allHadiths;
    }
}