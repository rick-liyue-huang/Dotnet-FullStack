
using API.Dtos;
using API.Models;
using API.Data;
using API.Features.Games.Constants;
using API.Features.Games.CreateGame;
using API.Features.Games.DeleteGame;
using API.Features.Games.GetGame;
using API.Features.Games.GetGames;
using API.Features.Games.UpdateGame;
using API.Features.Genres.GetGenres;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// const string getGameEndPointName = "GetGameName"; // move to Constants/EndpointName

GameStoreData gameStoreData = new();


// GET /games
// move to Features/Games/GetGames
app.MapGetGames(gameStoreData);

// GET /games/{id}
// Move to Features/Games/GetGame
app.MapGetGame(gameStoreData);

// POST /games
// move to Features/Games/CreateGame
app.MapCreateGame(gameStoreData);

// PUT /games/{id}
// move to Features/Games/UpdateGame
app.MapUpdateGame(gameStoreData);

// DELETE /games/{id}
// move to Features/Games/DeleteGame
app.MapDeleteGame(gameStoreData);

// GET /genres
// move to Features/Genres/
app.MapGetGenres(gameStoreData);

app.Run(url: "http://localhost:5000"); // can change the url here

