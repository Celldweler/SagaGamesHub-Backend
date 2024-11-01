using Microsoft.EntityFrameworkCore;
using SagaGamesHub.Core.Domain;
using SagaGamesHub.Data.Context;
using SagaGamesHub.Services.Games;

namespace SagaGamesHub.Tests.Services;

[TestFixture]
public class GameServiceTest
{
    private DbContextOptions<SagaGamesHubDbContext> dbContextOptions;

    [SetUp]
    public async Task SetUp()
    {
        dbContextOptions = new DbContextOptionsBuilder<SagaGamesHubDbContext>()
            .UseInMemoryDatabase(databaseName: "SagaGamesHubTestDB")
            .EnableSensitiveDataLogging()
            .Options;

        await Seed();

    }

    [Test]
    public void GetAllGames()
    {
        // Arrange
        using var context = GetContext();
        var gameService = new GameService(context);
        
        // Act
        var result = gameService.GeAll();
        
        // Assert
        Assert.IsInstanceOf<IReadOnlyList<Game>>(result);
    }
    
    private SagaGamesHubDbContext GetContext() => new SagaGamesHubDbContext(dbContextOptions);
    
    private async Task Seed()
    {
        await using var context = GetContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.SaveChangesAsync();
    }
}