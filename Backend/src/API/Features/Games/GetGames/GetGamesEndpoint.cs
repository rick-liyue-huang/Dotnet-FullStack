using API.Data;
using API.Features.Games.Constants;

namespace API.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapGet("/", () => data
            .GetGames()
            .Select(g => new GameSummaryDto(
                g.Id,
                g.Name,
                g.Description,
                g.Genre.Name,
                g.Price,
                g.ReleaseDate)));
    }
}