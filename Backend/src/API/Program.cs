
using API.Data;
using API.Features.Games;
using API.Features.Genres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var defaultConnection = builder.Configuration.GetConnectionString("GameStoreSqlConnection");

/*
  What services lifetime to use for a dbContext?
  DbContext is a singleton, so we use singleton
  DbContext created -> entity changes tracked -> save changes -> dbContext disposed
  Db connection is expensive, and dbContext is not thread safe, 
  Increasing memory usage due to change tracking
  
  USE Scopes for dbContext
  aligned with the context lifetime to the lifetime of the request
  there is only one thread executing the request at a time
  ensure each request has its own dbContext instance
 */

builder.Services.AddSqlite<GameStoreContext>(defaultConnection);
// builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlite(connectingString));

// Register services here
builder.Services.AddTransient<GameDataLogger>();
builder.Services.AddSingleton<GameStoreData>();

var app = builder.Build();

// const string getGameEndPointName = "GetGameName"; // move to Constants/EndpointName

// GameStoreData gameStoreData = new();

// No more used in database.
// app.MapGamesEndpoints();
// app.MapGenresEndpoints();

app.InitializeDb();

app.Run(url: "http://localhost:5000"); // can change the url here


// dotnet-ef from nuget.org : dotnet tool install --global dotnet-ef
// dotnet ef migrations add InitialCreate --output-dir Data/Migrations
// dotnet ef migrations add InitialCreate
// dotnet ef database update

