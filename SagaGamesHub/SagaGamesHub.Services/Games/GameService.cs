using Microsoft.EntityFrameworkCore;
using SagaGamesHub.Core.Domain;
using SagaGamesHub.Data.Context;

namespace SagaGamesHub.Services.Games;

public class GameService : IGameService
{
    private readonly SagaGamesHubDbContext _context;

    public GameService(SagaGamesHubDbContext context)
    {
        _context = context;
    }
    
    public IReadOnlyList<Game> GeAll()
    {
        return _context.Games
            .AsNoTracking()
            .ToList();
    }
}