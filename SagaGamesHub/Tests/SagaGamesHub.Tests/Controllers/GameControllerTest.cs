using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SagaGamesHub.Core.Domain;
using SagaGamesHub.Services.Games;
using SagaGamesHub.WebApi.Controllers;

namespace SagaGamesHub.Tests;

public class GameControllerTest
{
    private GameController controller;
    private IGameService gameService;

    [SetUp]
    public void Setup()
    {
        gameService = Substitute.For<IGameService>();
        
        controller = new GameController(gameService);
    }

    [Test]
    public void GetAll_ReturnsListOfGames()
    {
        // Act
        var result = controller.GetAll();
        var games = (result as OkObjectResult)?.Value;
        
        // Arrange
        Assert.IsInstanceOf<IReadOnlyList<Game>>(games);
    }
    
    [Test]
    public void GetAll_ReturnsOkObjectResult()
    {
        // Act
        var result = controller.GetAll();
        
        // Arrange
        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}