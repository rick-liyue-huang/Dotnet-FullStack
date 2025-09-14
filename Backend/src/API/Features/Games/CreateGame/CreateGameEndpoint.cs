using API.Data;
using API.Features.Games.Constants;
using API.Models;

namespace API.Features.Games.CreateGame;

public static class CreateGameEndpoint
{
    public static void MapCreateGame(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", (
            CreateGameDto gameDto, 
            // GameStoreData data, 
            GameStoreContext dbContext, // from internal data to the real database,
            GameDataLogger logger) =>
        {
            // var genre = data.GetGenre(gameDto.GenreId); //genres.Find(g => g.Id == gameDto.GenreId);
            // if (genre is null)
            // {
            //     return Results.BadRequest();
            // }
    
            var game = new Game
            {
                // Id = Guid.NewGuid(),
                Name = gameDto.Name,
                Description = gameDto.Description,
                // Genre = genre,
                // GenreId = genre.Id,
                GenreId = gameDto.GenreId,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate
            };
            // games.Add(game);
            // data.AddGame(game);
            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            
            logger.PrintGames();
            
            return Results.CreatedAtRoute(
                EndpointNames.GetGame,
                new { id = game.Id },
                new GameDetailsDto(
                    game.Id, 
                    game.Name, 
                    game.Description, 
                    // game.Genre.Id, 
                    game.GenreId,
                    game.Price, 
                    game.ReleaseDate));
        }).WithParameterValidation();
    }
}