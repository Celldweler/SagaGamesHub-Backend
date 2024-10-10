using Microsoft.EntityFrameworkCore;
using SagaGamesHub.Core.Domain;
using SagaGamesHub.Data.Context;
using SagaGamesHub.Services.Games;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddDbContext<SagaGamesHubDbContext>(options => options.UseInMemoryDatabase("Dev"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
    });
}

app.UseHttpsRedirection();
app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SagaGamesHubDbContext>();
    SeedData(dbContext);
}

app.Run();

void SeedData(SagaGamesHubDbContext context)
{
    if (!context.Games.Any())
    {
        context.Games.AddRange(new List<Game>
        {
            new() { Name = "The Legend of Zelda" },
            new() { Name = "Super Mario Bros." },
            new() { Name = "Minecraft" },
            new() { Name = "Overwatch" }
        });

        context.SaveChanges();
    }
}