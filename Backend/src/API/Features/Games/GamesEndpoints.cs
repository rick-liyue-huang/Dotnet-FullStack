using API.Data;
using API.Features.Games.CreateGame;
using API.Features.Games.DeleteGame;
using API.Features.Games.GetGame;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGame;

namespace API.Features.Games;

public static class GamesEndpoints
{
    public static void MapGamesEndpoints(this IEndpointRouteBuilder app, GameStoreData data)
    {

        var group = app.MapGroup("/games");
        // GET /games
        // move to Features/Games/GetGames
        group.MapGetGames(data);

        // GET /games/{id}
        // Move to Features/Games/GetGame
        group.MapGetGame(data);

        // POST /games
        // move to Features/Games/CreateGame
        group.MapCreateGame(data);

        // PUT /games/{id}
        // move to Features/Games/UpdateGame
        group.MapUpdateGame(data);

        // DELETE /games/{id}
        // move to Features/Games/DeleteGame
        group.MapDeleteGame(data);

    }   
}