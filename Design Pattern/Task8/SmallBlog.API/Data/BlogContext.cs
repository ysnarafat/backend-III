using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Models;

namespace SmallBlog.API.Data;

// Data/BlogContext.cs
public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserPostSupport> UserPostSupports { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Bundle> Bundles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<UserPostSupport>(entity =>
        {
            entity.HasKey(e => new { e.SupporterId, e.PostId });

            entity.HasOne(e => e.Supporter)
                .WithMany()
                .HasForeignKey(e => e.SupporterId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Post)
                .WithMany()
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<BookBundle>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.BundleId });

            entity.HasOne(e => e.Book)
                .WithMany(e => e.BookBundles)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Bundle)
                .WithMany(e => e.BookBundles)
                .HasForeignKey(e => e.BundleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
