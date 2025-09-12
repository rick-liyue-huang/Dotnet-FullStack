using API.Data;

namespace API.Features.Games.UpdateGame;

public static class UpdateGameEndpoint
{
    public static void MapUpdateGame(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", (Guid id, PutGameDto updatedGameDto, GameStoreData data) =>
        {
            var genre = data.GetGenre(updatedGameDto.GenreId); //.Find(g => g.Id == updatedGameDto.GenreId);
            if (genre is null)
            {
                return Results.BadRequest();
            }
    
    
            // var existingGame = games.Find(g => g.Id == id);
            var existingGame = data.GetGame(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Description = updatedGameDto.Description;
            existingGame.Genre = genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;

            return Results.NoContent();
        }).WithParameterValidation();
    }
}