using SagaGamesHub.Core.Domain;

namespace SagaGamesHub.Services.Games;

public interface IGameService
{
    IReadOnlyList<Game> GeAll();
}