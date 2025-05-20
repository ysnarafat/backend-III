using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Data;
using Microsoft.EntityFrameworkCore;
using SmallBlog.API.Services;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<BlogContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5432;Database=blog-db;User Id=user;Password=p@ssw0rd;"));

        builder.Services.AddScoped<BlogContext>();
        builder.Services.AddScoped<SupportStrategyFactory>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddControllers();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.MapOpenApi();
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
