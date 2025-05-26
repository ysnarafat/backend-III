using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.DTOs.Responses;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public interface IPostService
{
    Task<PostDto> GetPostAsync(int id);
    Task<bool> SupportPostAsync(SupportPostDto dto);
}
