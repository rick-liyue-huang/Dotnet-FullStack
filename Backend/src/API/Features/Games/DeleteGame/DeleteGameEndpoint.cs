using API.Data;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapDelete(("/games/{id}"), (Guid id) =>
        {
            var existingGame = data.GetGame(id); // Find(g => g.Id == id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            data.RemoveGame(id);
            return Results.NoContent();
        });

    }
}