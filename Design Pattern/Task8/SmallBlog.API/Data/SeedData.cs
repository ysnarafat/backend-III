using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Models;

namespace SmallBlog.API.Data;

public static class SeedData
{
    public static void Initialize(BlogContext context)
    {
        context.Database.Migrate(); // Apply pending migrations first
    
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Id = 1, Name = "Admin", IsAdmin = true },
                new User { Id = 2, Name = "User", IsAdmin = false }
            );
            context.SaveChanges();
        }
    }
}