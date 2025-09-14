using API.Data;
using API.Features.Games.Constants;
using API.Models;

namespace API.Features.Games.GetGame;

public static class GetGameEndpoint
{
    public static void MapGetGame(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", (Guid id, GameStoreData data) =>
        {
            // Game? game = games.Find(g => g.Id == id);
            Game? game = data.GetGame(id);
            return game is null ? Results.NotFound() : Results.Ok(new GameDetailsDto(
                game.Id, 
                game.Name, 
                game.Description, 
                game.GenreId, 
                game.Price, 
                game.ReleaseDate));
        }).WithName(EndpointNames.GetGame);
    }
}