
using API.Dtos;
using API.Models;
using API.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getGameEndPointName = "GetGameName";

GameStoreData gameStoreData = new();


// GET /games
app.MapGet("/games", () => gameStoreData.GetGames().Select(g => new GameSummaryDto(
    g.Id, 
    g.Name, 
    g.Description, 
    g.Genre.Name, 
    g.Price, 
    g.ReleaseDate)))
    .WithName("GetGames");;

// GET /games/{id}
app.MapGet("/games/{id}", (Guid id) =>
{
    // Game? game = games.Find(g => g.Id == id);
    Game? game = gameStoreData.GetGame(id);
    return game is null ? Results.NotFound() : Results.Ok(new GameDetailsDto(
        game.Id, 
        game.Name, 
        game.Description, 
        game.Genre.Id, 
        game.Price, 
        game.ReleaseDate));
}).WithName(getGameEndPointName);

// POST /games
app.MapPost("/games", (CreateGameDto gameDto) =>
{
    var genre = gameStoreData.GetGenre(gameDto.GenreId); //genres.Find(g => g.Id == gameDto.GenreId);
    if (genre is null)
    {
        return Results.BadRequest();
    }
    
    var game = new Game
    {
        // Id = Guid.NewGuid(),
        Name = gameDto.Name,
        Description = gameDto.Description,
        Genre = genre,
        Price = gameDto.Price,
        ReleaseDate = gameDto.ReleaseDate
    };
    // games.Add(game);
    gameStoreData.AddGame(game);
    return Results.CreatedAtRoute(
        getGameEndPointName,
        new { id = game.Id },
        new GameDetailsDto(
            game.Id, 
            game.Name, 
            game.Description, 
            game.Genre.Id, 
            game.Price, 
            game.ReleaseDate));
}).WithParameterValidation();

// PUT /games/{id}
app.MapPut("/games/{id}", (Guid id, PutGameDto updatedGameDto) =>
{
    var genre = gameStoreData.GetGenre(updatedGameDto.GenreId); //.Find(g => g.Id == updatedGameDto.GenreId);
    if (genre is null)
    {
        return Results.BadRequest();
    }
    
    
    // var existingGame = games.Find(g => g.Id == id);
    var existingGame = gameStoreData.GetGame(id);
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

// DELETE /games/{id}
app.MapDelete(("/games/{id}"), (Guid id) =>
{
    var existingGame = gameStoreData.GetGame(id); // Find(g => g.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    gameStoreData.RemoveGame(id);
    return Results.NoContent();
});


// GET /genres
app.MapGet("/genres", () => gameStoreData.GetGenres().Select(g => new GenreDto(g.Id, g.Name)));


app.Run(url: "http://localhost:5000"); // can change the url here

