using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Games.DeleteGame;

public static class DeleteGameEndpoint
{
    public static void MapDeleteGame(this IEndpointRouteBuilder app)
    {
        app.MapDelete(("/{id}"), (
            Guid id, 
            // GameStoreData data
            GameStoreContext dbContext // from internal data to the real database
            ) =>
        {
            // var existingGame = data.GetGame(id); // Find(g => g.Id == id);
            // if (existingGame is null)
            // {
            //     return Results.NotFound();
            // }

            // data.RemoveGame(id);
            dbContext.Games
                .Where(g => g.Id == id)
                .ExecuteDelete();
            return Results.NoContent();
        });

    }
}