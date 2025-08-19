using Microsoft.AspNetCore.Mvc;
using SmallBlog.API.Services;

namespace SmallBlog.API.Controllers;

[ApiController]
[Route("api/bundles")]
public class BundleController(IBundleService service) : ControllerBase
{
    [HttpGet("{bundleId}")]
    public async Task<IActionResult> Get(int bundleId)
    {
        var books = await service.GetBooksAsync(bundleId);

        return Ok(books);
    }
}