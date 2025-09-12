
using API.Data;
using API.Features.Games;
using API.Features.Genres;

var builder = WebApplication.CreateBuilder(args);


// Register services here
builder.Services.AddTransient<GameDataLogger>();
builder.Services.AddSingleton<GameStoreData>();

var app = builder.Build();

// const string getGameEndPointName = "GetGameName"; // move to Constants/EndpointName

// GameStoreData gameStoreData = new();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

app.Run(url: "http://localhost:5000"); // can change the url here

