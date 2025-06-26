using Microsoft.AspNetCore.Mvc;
using SmallBlog.API.Services;
using SmallBlog.External.AsSunnahFoundation;

namespace SmallBlog.API.Controllers;

[ApiController]
[Route("api/dailyhadiths")]
public class DailyHadithController(IHadithService service): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDailyHadiths()
    {
        var allHadiths = await service.GetDailyHadiths();
        return Ok(allHadiths);
    }
}