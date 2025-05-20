using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public interface IPostSupportStrategy
{
    Task AddSupportAsync(User author, User supporter,  Post post);
}