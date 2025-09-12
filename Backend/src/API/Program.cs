
using API.Data;
using API.Features.Games;
using API.Features.Genres;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// const string getGameEndPointName = "GetGameName"; // move to Constants/EndpointName

GameStoreData gameStoreData = new();

app.MapGamesEndpoints(gameStoreData);
app.MapGenresEndpoints(gameStoreData);

app.Run(url: "http://localhost:5000"); // can change the url here

