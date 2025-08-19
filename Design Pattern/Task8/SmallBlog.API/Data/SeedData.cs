using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Models;

namespace SmallBlog.API.Data;

public static class SeedData
{
    public static void Initialize(BlogContext context)
    {
        context.Database.Migrate();

        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Id = 1, Name = "Admin", IsAdmin = true },
                new User { Id = 2, Name = "User", IsAdmin = false }
            );
            context.SaveChanges();
        }

        if (!context.Bundles.Any())
        {
            context.Bundles.AddRange(
                [new Bundle
                {
                    Id = 1,
                    Title = "Book Bundle 1",
                    Description = "Test Bundle Description 1",
                    Books = new List<Book> {
                        new Book
                        {
                                Id = 1,
                                Title = "Book 1",
                                Author = "Author 1",
                                Summary = "Book 1 Summary",
                                ImageUrl = "http://example.com/image/1",
                                Publisher = "Publisher",
                                PageCount = 400
                        }
                    }
                },
                new Bundle
                {
                    Id = 2,
                    Title = "Book Bundle 2",
                    Description = "Test Bundle Description 2",
                    Books = new List<Book> {
                        new Book
                            {
                                Id = 2,
                                Title = "Book 2",
                                Author = "Author 2",
                                Summary = "Book 2 Summary",
                                ImageUrl = "http://example.com/image/2",
                                Publisher = "Publisher",
                                PageCount = 500
                            },
                    }
                }
                ]
            );
            context.SaveChanges();
        }
    }
}
