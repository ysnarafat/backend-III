using Microsoft.AspNetCore.Mvc;
using SmallBlog.API.Services;

namespace SmallBlog.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class BundleController(IBundleService service): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var books = await service.GetBooks(id);
        
        return Ok(books);
    }
}