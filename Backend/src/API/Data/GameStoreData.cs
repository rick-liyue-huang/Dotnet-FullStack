using API.Models;

namespace API.Data;

public class GameStoreData
{
    private readonly List<Genre> _genres =
    [
        new Genre { Id = new Guid("4e179397-c3f1-45ec-a271-c26f07ff64f3"), Name = "Fighting" },
        new Genre { Id = new Guid("c3d4e5f6-7890-a1b2-c3d4-e5f67890a1b2"), Name = "Kids and Family" },
        new Genre { Id = new Guid("d4e5f678-90a1-b2c3-d459-f67890a1b2c3"), Name = "Racing" },
        new Genre { Id = new Guid("e5f67890-a1b2-c3d4-e5f6-7890a1b2c3d4"), Name = "Roleplaying" },
        new Genre { Id = new Guid("f67890a1-b2c3-d4e5-f678-90a1b2c3d4e5"), Name = "Action RPG" },
        new Genre { Id = new Guid("0a1b2c3d-4e5f-6789-0a1b-2c3d4e5f6789"), Name = "Simulation" },
        new Genre { Id = new Guid("1b2c3d4e-5f67-890a-1b2c-3d4e5f67890a"), Name = "Strategy" },
    ];

    private readonly List<Game> _games;

    public GameStoreData()
    {
        _games = 
        [
            new Game 
            { 
                Id = Guid.NewGuid(), 
                Name = "The Legend of Zelda: Breath of the Wild", 
                Description = "The Legend of Zelda: Breath of the Wild is a 2022 action-adventure game developed by Nintendo.",
                Genre = _genres[0], 
                GenreId = _genres[0].Id,
                Price = 59.99m, 
                ReleaseDate = new DateOnly(2017, 3, 3) 
            },
            new Game 
            { 
                Id = Guid.NewGuid(), 
                Name = "Red Dead Redemption 2", 
                Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed by Rockstar North.",
                Genre = _genres[3], 
                GenreId = _genres[3].Id,
                Price = 49.99m, 
                ReleaseDate = new DateOnly(2018, 10, 26) 
            },
            new Game 
            { 
                Id = Guid.NewGuid(), 
                Name = "Elden Ring", 
                Description = "Elden Ring is a 2018 action-adventure game developed by Rockstar North.",
                Genre = _genres[2], 
                GenreId = _genres[2].Id,
                Price = 59.99m, 
                ReleaseDate = new DateOnly(2022, 2, 25) 
            },
            new Game 
            { 
                Id = Guid.NewGuid(), 
                Name = "Cyberpunk 2077", 
                Description = "Cyberpunk 2077 is a 2022 action-adventure game developed by CD Projekt Red.",
                Genre = _genres[1], 
                GenreId = _genres[1].Id,
                Price = 49.99m, 
                ReleaseDate = new DateOnly(2020, 12, 10) 
            },
            new Game 
            { 
                Id = Guid.NewGuid(), 
                Name = "God of War Ragnarök", 
                Description = "this is new game",
                Genre = _genres[5], 
                GenreId = _genres[5].Id,
                Price = 69.99m, 
                ReleaseDate = new DateOnly(2022, 11, 9) 
            }
        ];
    }
    
    public IEnumerable<Genre> GetGenres() => _genres;
    public Genre? GetGenre(Guid id) => _genres.Find(g => g.Id == id);
    public IEnumerable<Game> GetGames() => _games;
    public Game? GetGame(Guid id) => _games.Find(g => g.Id == id);
    public void AddGame(Game game)
    {
        game.Id = Guid.NewGuid();
        _games.Add(game);
    }

    public void RemoveGame(Guid id)
    {
        _games.RemoveAll(g => g.Id == id);
    }
    
    
}