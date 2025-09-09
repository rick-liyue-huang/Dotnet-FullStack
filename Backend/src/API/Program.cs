
using API.Dtos;
using API.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getGameEndPointName = "GetGameName";

List<Genre> genres =
[
    new Genre { Id = new Guid("4e179397-c3f1-45ec-a271-c26f07ff64f3"), Name = "Fighting" },
    new Genre { Id = new Guid("c3d4e5f6-7890-a1b2-c3d4-e5f67890a1b2"), Name = "Kids and Family" },
    new Genre { Id = new Guid("d4e5f678-90a1-b2c3-d459-f67890a1b2c3"), Name = "Racing" },
    new Genre { Id = new Guid("e5f67890-a1b2-c3d4-e5f6-7890a1b2c3d4"), Name = "Roleplaying" },
    new Genre { Id = new Guid("f67890a1-b2c3-d4e5-f678-90a1b2c3d4e5"), Name = "Action RPG" },
    new Genre { Id = new Guid("0a1b2c3d-4e5f-6789-0a1b-2c3d4e5f6789"), Name = "Simulation" },
    new Genre { Id = new Guid("1b2c3d4e-5f67-890a-1b2c-3d4e5f67890a"), Name = "Strategy" },
];

List<Game> games =
[
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "The Legend of Zelda: Breath of the Wild", 
        Description = "The Legend of Zelda: Breath of the Wild is a 2022 action-adventure game developed by Nintendo.",
        Genre = genres[0], 
        Price = 59.99m, 
        ReleaseDate = new DateOnly(2017, 3, 3) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Red Dead Redemption 2", 
        Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed by Rockstar North.",
        Genre = genres[3], 
        Price = 49.99m, 
        ReleaseDate = new DateOnly(2018, 10, 26) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Elden Ring", 
        Description = "Elden Ring is a 2018 action-adventure game developed by Rockstar North.",
        Genre = genres[2], 
        Price = 59.99m, 
        ReleaseDate = new DateOnly(2022, 2, 25) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Cyberpunk 2077", 
        Description = "Cyberpunk 2077 is a 2022 action-adventure game developed by CD Projekt Red.",
        Genre = genres[1], 
        Price = 49.99m, 
        ReleaseDate = new DateOnly(2020, 12, 10) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "God of War Ragnarök", 
        Description = "this is new game",
        Genre = genres[5], 
        Price = 69.99m, 
        ReleaseDate = new DateOnly(2022, 11, 9) 
    }
];

// GET /games
app.MapGet("/games", () => games.Select(g => new GameSummaryDto(
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
    Game? game = games.Find(g => g.Id == id);
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
    var genre = genres.Find(g => g.Id == gameDto.GenreId);
    if (genre is null)
    {
        return Results.BadRequest();
    }
    
    var game = new Game
    {
        Id = Guid.NewGuid(),
        Name = gameDto.Name,
        Description = gameDto.Description,
        Genre = genre,
        Price = gameDto.Price,
        ReleaseDate = gameDto.ReleaseDate
    };
    games.Add(game);
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
    var genre = genres.Find(g => g.Id == updatedGameDto.GenreId);
    if (genre is null)
    {
        return Results.BadRequest();
    }
    
    
    var existingGame = games.Find(g => g.Id == id);
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
    var existingGame = games.Find(g => g.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    games.Remove(existingGame);
    return Results.NoContent();
});


// GET /genres
app.MapGet("/genres", () => genres.Select(g => new GenreDto(g.Id, g.Name)));


app.Run(url: "http://localhost:5000"); // can change the url here

