using Microsoft.AspNetCore.Mvc;
using SmallBlog.API.Data;
using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.Models;
using SmallBlog.API.Services;

namespace SmallBlog.API.Controllers;

[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly BlogContext _context;
    private readonly IPostService _postService;

    public PostsController(BlogContext context, IPostService postService)
    {
        _context = context;
        _postService = postService;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(CreatePostDto dto)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = dto.UserId
        };

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return Ok();
    }

    [HttpPost("{id}/comments")]
    public async Task<ActionResult<Comment>> AddComment(int id, CreateCommentDto dto)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();

        var comment = new Comment
        {
            Text = dto.Text,
            PostId = id,
            UserId = dto.UserId
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return Ok(comment);
    }
    
    [HttpPost("{id}/support")]
    public async Task<ActionResult<Comment>> SupportPost(int id, SupportPostDto dto)
    {
        dto.PostId = id;
        var result = await _postService.SupportPostAsync(dto);
        
        return  result ? Ok() : BadRequest();
    }
}
