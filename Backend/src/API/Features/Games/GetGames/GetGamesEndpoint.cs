using API.Data;
using API.Features.Games.Constants;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (
            // GameStoreData data
            GameStoreContext dbContext // from internal data to the real database
            ) => 
            // data
            dbContext.Games
                .Include(game => game.Genre)
            // .GetGames()
            .Select(g => new GameSummaryDto(
                g.Id,
                g.Name,
                g.Description,
                g.Genre!.Name,
                g.Price,
                g.ReleaseDate))
                .AsNoTracking());
    }
}