using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public interface IPostService
{
    Task<bool> SupportPostAsync(SupportPostDto dto);
}
