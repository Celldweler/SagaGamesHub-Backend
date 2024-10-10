using Microsoft.EntityFrameworkCore;
using SagaGamesHub.Core.Domain;

namespace SagaGamesHub.Data.Context;

public class SagaGamesHubDbContext : DbContext
{
    public SagaGamesHubDbContext(DbContextOptions<SagaGamesHubDbContext> options)
        : base(options) 
    {
    }

    public DbSet<Game> Games { get; set; }
}