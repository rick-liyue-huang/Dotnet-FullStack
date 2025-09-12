using API.Data;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app)
    {
        app.MapDelete(("/{id}"), (Guid id, GameStoreData data) =>
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