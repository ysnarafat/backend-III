using SmallBlog.API.Data;
using SmallBlog.API.DTOs.Requests;
using SmallBlog.API.Models;

namespace SmallBlog.API.Services;

public class SupportStrategyFactory
{
    private readonly BlogContext _context;

    public SupportStrategyFactory(BlogContext context)
    {
        _context = context;
    }
    
    public IPostSupportStrategy GetPostSupportStrategy(User user)
    {
        if (user.IsAdmin)
        {
            return new AdminPostSupportStrategy(_context);
        }
        
        return new MemberPostSupportStrategy(_context);
    }
}