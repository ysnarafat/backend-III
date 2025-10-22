using UserAuthBackend.Models;
using UserAuthBackend.Processors;
using UserAuthBackend.Services;
using UserAuthBackend.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserQueue, UserQueue>();
builder.Services.AddSingleton<AuthBackend>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddScoped<CsvProcessor>();
builder.Services.AddHostedService<UserWorker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/upload-csv", async (IFormFile file, IUserQueue queue, CsvProcessor processor) =>
{
    if (file.Length > 5_000_000) return Results.BadRequest("File too large");

    using var reader = new StreamReader(file.OpenReadStream());
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        await processor.Process(line);
    }

    return Results.Ok("CSV processed and users enqueued.");
}).DisableAntiforgery();

app.Run();
