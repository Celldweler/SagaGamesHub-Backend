using Microsoft.AspNetCore.Mvc;
using SagaGamesHub.Services.Games;

namespace SagaGamesHub.WebApi.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var games = _gameService.GeAll();
        return Ok(games);
    }
}