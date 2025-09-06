
using API.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndPointName = "GetGameName";

List<Game> games =
[
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "The Legend of Zelda: Breath of the Wild", 
        Genre = "Action-Adventure", 
        Price = 59.99m, 
        ReleaseDate = new DateOnly(2017, 3, 3) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Red Dead Redemption 2", 
        Genre = "Action-Adventure", 
        Price = 49.99m, 
        ReleaseDate = new DateOnly(2018, 10, 26) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Elden Ring", 
        Genre = "Action RPG", 
        Price = 59.99m, 
        ReleaseDate = new DateOnly(2022, 2, 25) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "Cyberpunk 2077", 
        Genre = "Action RPG", 
        Price = 49.99m, 
        ReleaseDate = new DateOnly(2020, 12, 10) 
    },
    new Game 
    { 
        Id = Guid.NewGuid(), 
        Name = "God of War Ragnarök", 
        Genre = "Action-Adventure", 
        Price = 69.99m, 
        ReleaseDate = new DateOnly(2022, 11, 9) 
    }
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(g => g.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndPointName);

// POST /games
app.MapPost("/games", (Game game) =>
{
    game.Id = Guid.NewGuid();
    games.Add(game);
    return Results.CreatedAtRoute(
        GetGameEndPointName,
        new { id = game.Id },
        game);
}).WithParameterValidation();

// PUT /games/{id}
app.MapPut("/games/{id}", (Guid id, Game updatedGame) =>
{
    var existingGame = games.Find(g => g.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;

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

app.Run(url: "http://localhost:5000"); // can change the url here

