using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Data;
using SmallBlog.API.Models;
using SmallBlog.API.Services;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<BlogContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5432;Database=blog-db;User Id=user;Password=p@ssw0rd;"));

        builder.Services.AddScoped<BlogContext>();
        builder.Services.AddScoped<SupportStrategyFactory>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IHadithService, HadithService>();
        builder.Services.AddScoped<IBundleService, BundleService>();
        builder.Services.AddScoped<ICacheService<Post, int>, PostCacheService>();
        builder.Services.AddScoped<ICacheService<Bundle, int>, BundleCacheService>();
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<BlogContext>();
            SeedData.Initialize(db);
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}
