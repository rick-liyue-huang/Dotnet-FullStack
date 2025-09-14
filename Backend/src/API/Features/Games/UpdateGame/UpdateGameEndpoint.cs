using API.Data;

namespace API.Features.Games.UpdateGame;

public static class UpdateGameEndpoint
{
    public static void MapUpdateGame(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", (
            Guid id, 
            PutGameDto updatedGameDto, 
            // GameStoreData data
            GameStoreContext dbContext // from internal data to the real database
            ) =>
        {
            // var genre = data.GetGenre(updatedGameDto.GenreId); //.Find(g => g.Id == updatedGameDto.GenreId);
            // if (genre is null)
            // {
            //     return Results.BadRequest();
            // }
    
    
            // var existingGame = games.Find(g => g.Id == id);
            // var existingGame = data.GetGame(id);
            var existingGame = dbContext.Games.Find(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Description = updatedGameDto.Description;
            // existingGame.Genre = genre;
            // existingGame.GenreId = genre.Id;
            existingGame.GenreId = updatedGameDto.GenreId;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            
            dbContext.SaveChanges();

            return Results.NoContent();
        }).WithParameterValidation();
    }
}